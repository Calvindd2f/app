# Orchestration.chat_activity.activity_handler.inline_powershell - Durable Function

1. Orchestrator Function (Overall Workflow)

This function orchestrates the sequence of steps, managing the state and flow of operations between activities.

```csharp
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

[FunctionName("MainOrchestrator")]
public static async Task RunOrchestrator(
    [OrchestrationTrigger] IDurableOrchestrationContext context)
{
    var userInput = await context.CallActivityAsync<string>("ChatActivity", "Get user input");
    var processedInput = await context.CallActivityAsync<string>("GeneralActivityHandler", userInput);
    var validationResult = await context.CallActivityAsync<bool>("InlinePowerShell", processedInput);

    if (validationResult)
    {
        await context.CallActivityAsync("ChatActivity", "Update whitelist with user data");
    }
}
```

2. General Activity Handler Function

This function handles generic activities like interacting with databases, APIs, or performing complex logic.

```csharp
[FunctionName("GeneralActivityHandler")]
public static string HandleActivity([ActivityTrigger] string input)
{
    // Implement the logic based on input
    // Example: API call to verify or modify data
    return "Processed data based on input: " + input;
}
```

3. Inline PowerShell Function

This function executes PowerShell scripts for quick operations or data manipulations.

```csharp
[FunctionName("InlinePowerShell")]
public static bool ExecutePowerShellScript([ActivityTrigger] string data)
{
    // Example PowerShell execution logic
    // Return true if the operation is successful
    return true;
}
```

4. Chat Activity Function

This function manages chat interactions, sending and receiving messages from the user.

```csharp
[FunctionName("ChatActivity")]
public static string ChatInteraction([ActivityTrigger] string message)
{
    // Simulate chat interaction
    // Return the response from the chatbot based on the message
    return "Response to: " + message;
}
```

## Configuration for Azure Bot

For the Azure Bot setup, you'll need to configure the bot to interact with these Durable Functions.

Here's an example setup using Bot Framework SDK:

## Bot Configuration

```csharp
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
```

## Deployment and Integration

Deploy these functions to your Azure Function App through the Azure portal or using Azure CLI. Ensure your bot is registered in Azure Bot Service and connected properly to these functions, typically via HTTP triggers or direct Azure Function bindings.

This architecture allows your bot to efficiently manage dialog flows, perform operations using PowerShell, and handle general tasks through the orchestrated Azure Durable Functions.