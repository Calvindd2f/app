// Azure Durable Functions architecture for your project. We'll create an orchestrator function that manages the workflow and individual activity functions for handling general activities, inline PowerShell, and chat interactions.
//1. Orchestrator Function (Overall Workflow)
//This function orchestrates the sequence of steps, managing the state and flow of operations between activities.
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
