# Dependencies - PowerShell, NuGet, TypeScript, NPM


```json
"nuget":[
    {
        "BuildDeploySupport":"dotnet add package BuildDeploySupport --version 0.1.0.4",
        "PoshStack" :"dotnet add package PoshStack --version 0.3.22",
        "splitpipeline":"dotnet add package SplitPipeline --version 1.6.3",
        "7zippowershell":"dotnet add package 7Zip4Powershell --version 1.9.0",
        "PowerTasks"
        "Pask":"dotnet add package Pask --version 0.35.0",
        "PowerShell.Deployment":"dotnet add package Powershell.Deployment --version 1.2.5",
        "Helps":"NuGet\\Install-Package Helps -Version 1.2.10",
        "AsyncProgressReporter":"NuGet\\Install-Package biz.dfch.PS.System.Utilities -Version 2.2.0",
        "Carbon":"NuGet\\Install-Package Carbon -Version 2.11.0",
        "PowerTasks ":"NuGet\\Install-Package PowerTasks -Version 3.1.1",
        "psakify":"NuGet\\Install-Package psakify -Version 0.2.0",
        "":"",
        "":"",
        "":"",
        "":"",
        "":"",
        "":"",
        "":"",
        "":"",
        "":"",
        "":""
    },
    {
        "Core - Client - AMQP":"",
        "Microsoft.Azure.SignalR.Emulator":"",
        "Microsoft.Azure.WebJobs.Core":"",
        "Microsoft.Azure.Functions.Analyzers":"NuGet\\Install-Package Microsoft.Azure.Functions.Analyzers -Version 1.0.0",
        "Microsoft.Extensions.DependencyInjection":"",
        "Microsoft.Azure.Functions.Extensions":"dotnet add package Microsoft.Azure.Functions.Extensions --version 1.1.0",
        "Microsoft.Azure.Functions.Worker.ProjectTemplates":"dotnet new install Microsoft.Azure.Functions.Worker.ProjectTemplates::4.0.2945",
        "Microsoft.Identity.Client":"dotnet add package Microsoft.Identity.Client --version 4.60.3",
        "Microsoft.Azure.Functions.Worker.ItemTemplates":"dotnet new install Microsoft.Azure.Functions.Worker.ItemTemplates::4.0.2945",
        "Microsoft.Azure.WebJobs.Script.ExtensionsMetadataGenerator":"dotnet add package Microsoft.Azure.WebJobs.Script.ExtensionsMetadataGenerator --version 4.0.1",
        "Microsoft.Azure.WebJobs.ProjectTemplates":"dotnet new install Microsoft.Azure.WebJobs.ProjectTemplates::4.0.2945",
        "Microsoft.Azure.WebJobs.Extensions.DurableTask":"dotnet add package Microsoft.Azure.WebJobs.Extensions.DurableTask --version 3.0.0-rc.1",
        "Microsoft.Azure.Functions.Worker.Sdk.Analyzers 1.2.1
":"dotnet add package Microsoft.Azure.Functions.Worker.Sdk.Analyzers --version 1.2.1",
        "Microsoft.Azure.Functions.Worker":"dotnet add package Microsoft.Azure.Functions.Worker --version 1.22.0",
        "Microsoft.Azure.Functions.Worker.Extensions.Abstractions":"dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Abstractions --version 1.3.0",
        "Microsoft.Azure.WebJobs.Extensions.DurableTask.Analyzers":"dotnet add package Microsoft.Azure.WebJobs.Extensions.DurableTask.Analyzers --version 0.5.0",
        "Microsoft.Azure.Functions.Worker.Grpc:":"dotnet add package Microsoft.Azure.Functions.Worker.Grpc --version 1.16.0",
        "Microsoft.Azure.Functions.Worker.Sdk ":"dotnet add package Microsoft.Azure.Functions.Worker.Sdk --version 1.17.3-preview1",
        "Microsoft.Azure.Functions.Worker.Sdk.Generators":"dotnet add package Microsoft.Azure.Functions.Worker.Sdk.Generators --version 1.2.1",
        "Microsoft.Azure.Functions.Worker.Extensions.Http":"",
        "Microsoft.Azure.WebJobs.Extensions.WebPubSub":"dotnet add package Microsoft.Azure.WebJobs.Extensions.WebPubSub --version 1.7.0",
        "Microsoft.Azure.Functions.Worker.Extensions.DurableTask":"",
        "Spe":"dotnet add package Spe --version 6.4.0",
        "Microsoft.Azure.Functions.Worker.Extensions.Abstractions":"dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Abstractions --version 1.3.0",
        "Autofac.Extensions.DependencyInjection.AzureFunctions":"dotnet add package Autofac.Extensions.DependencyInjection.AzureFunctions --version 7.2.0.92",
        "Microsoft.Azure.IoT.Edge.Function":"dotnet add package Microsoft.Azure.IoT.Edge.Function --version 3.5.3",
        "Microsoft.ApplicationInsights":"sotnet add package Microsoft.ApplicationInsights",
        "Microsoft.AspNetCore.Http":"sotnet add package Microsoft.AspNetCore.Http",
        "Microsoft.AspNetCore.Mvc":"sotnet add package Microsoft.AspNetCore.Mvc",
        "Microsoft.Extensions.Logging":"sotnet add package Microsoft.Extensions.Logging",
        "Microsoft.Azure.SignalR.Emulator":"null",
        "Microsoft.Azure.Functions.Worker.Extensions.Abstractions":"null",
        "Microsoft.Azure.SignalR.Emulator":"dotnet tool install --global Microsoft.Azure.SignalR.Emulator --version 1.1.0",
        "":"",
        "":"",
        "":""





        
    }
]


```

## Sitecore PowerShell Extensions






## Durable Functions

+ Select a template for your function DurableFunctionsOrchestration Create a Durable Functions orchestration
+ Provide a function name HelloOrchestration Name of the class in which functions are created
+ Provide a namespace Company.Function Namespace for the generated class

## Application patterns

+ Function chaining
+ Fan-out/fan-in
+ Async HTTP APIs
+ Monitoring
+ Human interaction
+ Aggregator (stateful entities)

## Useful links

+ <https://github.com/Azure/azure-functions-host>
+ <https://www.serverlesslibrary.net/>
+

## Useful package

```json
{
  "name": "azure-serverless-xxx",
  "version": "1.0.0",
  "description": "",
  "scripts": {
    "build": "tsc",
    "watch": "tsc -w",
    "prepack": "npx shx rm -rf dist node_modules && npm install && npm run build && npm prune --production --force",
    "pack": "tar --exclude-from=.funcignore -a -c -f out.zip .",
    "postpack": "npm install",
    "prestart": "npm run build",
    "start": "func start",
    "forward": "ngrok http 7071",
    "poststart": "ngrok http 7071",
    "test": "echo \"No tests yet...\""
  },
  "dependencies": {
    "name": "https://github.com/"
  },
  "devDependencies": {
    "@azure/functions": "^1.2.3",
    "@types/node": "^16.3.3",
    "@typescript-eslint/eslint-plugin": "^4.27.0",
    "@typescript-eslint/parser": "^4.27.0",
    "eslint": "^7.28.0",
    "typescript": "^4.0.0"
  }
}
```

### Usefulr package

```json
"PowerShell_Modules":[
    {
        "psm-psake":"psake",
    },
    {

    }
]
```

