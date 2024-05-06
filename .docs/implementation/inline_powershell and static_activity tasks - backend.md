# inline_powershell and static_activity tasks - backend

## Inline PowerShell Activities

The inline PowerShell activity is utilized for executing PowerShell scripts directly within your automation packages, without the need for separate PowerShell activity files. This capability is especially useful for quick data transformations, calculations, and manipulations.

Example Usage:

Performing Calculations: Small arithmetic operations or data transformations.
JSON/Object Manipulation: Transforming data between activities within the package.

```yaml

steps:
  - task: inline_powershell
    alias: 'result1'
    inputs:
      script: |
        return @{ a = 2; b = 3 };
        
  - task: inline_powershell
    alias: 'result2'
    inputs:
      numA: =result1.a
      numB: =result1.b
      script: |            
        return @{ result = [int]$numA * [int]$numB };
        
  - task: chat_interaction
    inputs:
      text: =result2.result
```

### Activity Behavior

Inline PowerShell activities are executed on a backend agent termed an "Activity Node". These activities allow for flexible input naming, which means that any named inputs can be accessed directly within your PowerShell script.

### Standard PowerShell Activity Template

For typical PowerShell activities, the template includes pre-defined functions such as VerifyActivity and ExecuteActivity, which handle verification and execution phases of the activity.

```powershell
Function VerifyActivity()
{        
    return $true;    
}

Function ExecuteActivity()
{
    $activityOutput.out.Variable1 = "something";
    $activityOutput.out.Variable2 = "something else";
    $activityOutput.success = $true;
    return $activityOutput;
}
```

### Configurable Properties

Activities can be configured with properties that alter execution behavior:

+ **executionEnvironment**: Defines the context of execution.
+ **executionEnvironmentKey**: Specifies agent details.
+ **executionClientId**: Identifies the client where the activity will run.
+ **alias**: Provides a unique identifier for the activity.
+ **skip**: Determines whether the activity should be skipped.
+ **document**: Documentation visible on the client dashboard.

### Calling and Using Activities

Activities are called within packages through YAML configuration, specifying inputs that are passed to the PowerShell script.

```yaml
- task: my_test_activity
  inputs:
    my_input: 'some value'
```

### Managing Outputs

Outputs from PowerShell activities are managed through the $activityOutput object, which holds output variables and execution status.

```powershell
# Hidden Test Code Section to initialize variables
$variableProps = @{my_output = $null;}
$outputProps = @{out = $(New-Object psobject - Property $variableProps); success = $false;}
$activityOutput = New-Object psobject -Property $outputProps;
```

This summary encapsulates the functionality and configuration of inline and standard PowerShell activities within your orchestrator. This setup facilitates dynamic and powerful automation workflows that can handle complex data operations and user interactions seamlessly.