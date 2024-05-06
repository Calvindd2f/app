# Chatbot Interface and FSM Workflow

Summary of your planned chatbot interface and the workflow for the Finite State Machine (FSM) along with how it integrates with the background processes:

## Chatbot Interface and FSM Workflow and Activity Handler

+ **Initial Greeting**: When the chatbot is opened, it greets the user and displays a list of available packages.

**Package Selection:**

The workflow is initiated when a user selects a package.
This uses `-task: chat_interaction` to manage the conversation, sending messages to the user and defining forms for user input.

Background Processes in a Workflow
The background processes consist of two primary tasks:

## Inline PowerShell Execution:

`-task: inline_powershell`
Executes PowerShell scripts directly within the workflow.

## Specific Activity Execution:

`-task: activity_name (e.g., azure_get_users)`
Manages the execution of predefined activities.

## YAML Configuration for Activities

Each step or activity in the workflow is defined in YAML format with the following structure:

```yaml
- task: 'activity_name'
  property name: 'property value'
  inputs:
    input_name: 'input_value'
```

## Definitions:

+ **activity_name**: The static name of the activity, which can be a built-in system activity or a custom PowerShell activity.
+ **property_name** and **property_value**: Attributes that modify the execution behavior of the activity. Examples include:
+ **executionEnvironment**: Defines the execution context (e.g., 'System', 'AsUser', 'AsUserElevated').
+ **executionEnvironmentKey**: Specifies the qualified name of the agent (e.g., 'DC01').
+ **executionClientId**: Identifies the client where the activity runs, typically the current client for the package.
+ **alias**: A unique alias for the activity within the package.
+ **skip**: A boolean to determine if the activity should be skipped.
+ **document**: Documentation details for the activity, visible on the client dashboard.
+ **input_name** and input_value: Specific inputs to the activity, variable per activity.
+ **Example** of Activity Call and Handling Outputs

Here’s how you can call an activity and handle its output:

```yaml
# Calling an activity with a static name of my_test_activity
- task: my_test_activity
  inputs:
    my_input: 'some value'

# Deserializing the output variable
- task: inline_powershell
  inputs:
    my_activities_output: =my_test_activity.my_output
  script: |
    $my_activities_output = [Array]$(ConvertFrom-Json $my_activities_output)
    foreach($output in $my_activities_output){
      Write-Host "Object property value: $($output.my_property)"
    }
```

This summary confirms your current setup for the chatbot's interface and its background processing workflows.