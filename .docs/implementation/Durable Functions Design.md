# Durable Functions Design - Activity Funtions - Orchestrator - inline_powershell

Converting your workflow to use Azure Durable Functions is an excellent idea for orchestrating complex processes with multiple steps, especially when you need reliable state management and coordination between asynchronous operations.

## Azure Durable Functions Design
Let’s start by defining how to organize your Durable Functions to make the most of this architecture:

+ **Orchestrator Function**: This is the core function that will manage the workflow, calling other activity functions as needed.
+ **Activity Functions**: These functions will perform specific tasks such as displaying forms, processing data, interacting with Exchange Online, etc.
+ **Inline PowerShell Function**: Handles quick PowerShell tasks that do not require file resolution or complex logic.

Here’s how you could set up and structure these functions:

## Orchestrator Function

The orchestrator function will manage the workflow sequence, ensuring each step is executed in the correct order and handling the state throughout the process.

```csharp
[FunctionName("OrchestratorFunction")]
public static async Task RunOrchestrator(
    [OrchestrationTrigger] IDurableOrchestrationContext context)
{
    var userInput = await context.CallActivityAsync<string>("GetUserInput", null);
    var processedInput = await context.CallActivityAsync<string>("ProcessInput", userInput);
    var validationResult = await context.CallActivityAsync<bool>("ValidateInput", processedInput);
    if (validationResult)
    {
        await context.CallActivityAsync("UpdateWhitelist", processedInput);
    }
    // Continue with further steps as needed
}
```

## Activity Functions

These functions are called by the orchestrator to perform specific tasks:

```csharp
[FunctionName("GetUserInput")]
public static string GetUserInput([ActivityTrigger] IDurableActivityContext context)
{
    // Code to display form and get input from the user
    return "user input";
}

[FunctionName("ProcessInput")]
public static string ProcessInput([ActivityTrigger] string input)
{
    // Code to process the input
    return "processed input";
}

[FunctionName("ValidateInput")]
public static bool ValidateInput([ActivityTrigger] string input)
{
    // Code to validate the input
    return true; // or false based on validation
}

[FunctionName("UpdateWhitelist")]
public static void UpdateWhitelist([ActivityTrigger] string input)
{
    // Code to update whitelist
}
```

## Inline PowerShell Function

This function handles inline PowerShell tasks, particularly useful for operations that are script-based and do not need to interact with external files or lengthy operations.

```csharp
[FunctionName("InlinePowerShell")]
public static void InlinePowerShell([ActivityTrigger] dynamic data)
{
    // PowerShell scripting logic here
}
```

## Efficient Use of Functions

### Regarding your question about efficiency with two functions

+ **A General Activity Handler Function:** This function would manage the resolution of activities to execute them based on dynamic parameters and could handle most of the operational logic.
+ **An Inline PowerShell Function:** Dedicated to handling PowerShell commands that are simpler and do not require the overhead of the first function.

### This separation can indeed be efficient

+ **Simplicity and Focus**: Each function focuses on a specific type of task, reducing complexity within each function.
+ **Performance Optimization**: The Inline PowerShell function can be optimized for quick execution and lower resource usage, while the Activity Handler function can be robust, handling more intensive tasks and possibly requiring more resources.

By structuring your application in this way, you can leverage `Azure Durable Functions` to orchestrate the workflow efficiently, while maintaining clarity and modularity in your codebase. 

This approach also ensures each component is responsible for a single aspect of the workflow, aligning with best practices in software architecture.