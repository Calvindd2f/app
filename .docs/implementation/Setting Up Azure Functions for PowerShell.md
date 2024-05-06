# Setting Up Azure Functions for PowerShell Execution

## Step 1: Create a Function App in Azure

Azure Portal > "Create a resource" > Compute > Function App.

Enter the required settings:
  **Subscription**: Choose your subscription.
  **Resource Group**: Select an existing resource group or create a new one.
  **Function App Name**: Enter a unique name.
  **Publish**: Choose "`Code`".
  **Runtime Stack**: Select "`PowerShell Core`".
  **Version**: Choose the latest available version.
  **Region**: Select the region closest to your users.

Review and create the Function App.

## Step 2: Develop and Deploy PowerShell Scripts

Develop your PowerShell scripts locally. Ensure they are designed to be triggered by HTTP requests or other bindings you plan to use.

Example PowerShell script (`HttpTriggeredScript.ps1`):

```powershell
param($Request, $TriggerMetadata)
$name = $Request.Query.Name
if (-not $name) {
    $name = $Request.Body.Name
}
Push-OutputBinding -Name Response -Value ([HttpResponseContext]@{
    StatusCode = [HttpStatusCode]::OK
    Body = "Hello, $name!"
})
```

### Deploy Scripts to Azure:

Use Visual Studio Code with the Azure Functions extension:

+ Open your project in VS Code.
+ Install the Azure Functions extension if not already installed.
+ Sign in to Azure through the extension.
+ Right-click your project in the Azure Functions explorer and select Deploy to Function App.
+ Follow the prompts to select your Function App and deploy.

## Step 3: Test Function Execution

Use the Azure Portal to navigate to your Function App and find the function you deployed.

Use the "`Get function URL`" button to copy the URL and test it by sending requests via a browser or Postman.
