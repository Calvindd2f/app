using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string? name = req.HttpContext.Request.Query["name"].FirstOrDefault();

            if (name == null)
            {
                using var reader = new StreamReader(req.Body, req.HttpContext.Request.ContentType?.Contains("utf") ?? false ? Encoding.UTF8 : Encoding.Default);
                name = await reader.ReadToEndAsync();
            }

            string responseMessage = name == null
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
        }
    }
}
