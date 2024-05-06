using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.Dialogs;

public class BotService : IBot
{
    private readonly ConversationState _conversationState;
    private readonly DialogSet _dialogs;

    public BotService(ConversationState conversationState)
    {
        _conversationState = conversationState;
        _dialogs = new DialogSet(_conversationState.CreateProperty<DialogState>("DialogState"));

        _dialogs.Add(new WaterfallDialog("mainDialog", new WaterfallStep[]
        {
            Step1Async,
            Step2Async,
            FinalStepAsync
        }));
    }

    private async Task<DialogTurnResult> Step1Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = MessageFactory.Text("Please enter your input:") }, cancellationToken);
    }

    private async Task<DialogTurnResult> Step2Async(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        var input = stepContext.Result.ToString();
        // Here you would call the orchestrator function, passing the input
        var result = await CallDurableFunction(input);
        return await stepContext.NextAsync(result, cancellationToken);
    }

    private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        // Process the result from the Durable Function
        var processResult = stepContext.Result.ToString();
        await stepContext.Context.SendActivityAsync(MessageFactory.Text("Processed result: " + processResult), cancellationToken);
        return await stepContext.EndDialogAsync(null, cancellationToken);
    }

    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
    {
        var dialogContext = await _dialogs.CreateContextAsync(turnContext, cancellationToken);
        var results = await dialogContext.ContinueDialogAsync(cancellationToken);

        if (results.Status == DialogTurnStatus.Empty)
        {
            await dialogContext.BeginDialogAsync("mainDialog", null, cancellationToken);
        }

        await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
    }
}
