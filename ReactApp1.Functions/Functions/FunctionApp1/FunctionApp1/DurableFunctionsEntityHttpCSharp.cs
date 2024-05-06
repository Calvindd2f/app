using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json.Linq;

namespace ReactApp1.Function.inline_powershell
{
    public static class DurableFunctionsEntityHttpCSharp
    {
        /// <summary>
        /// This is the main entry point for our durable function. 
        /// It's a HTTP triggered function that handles incoming requests 
        /// to operate on a specific entity.
        /// </summary>
        /// <param name="req">The HTTP request message.</param>
        /// <param name="client">The durable entity client.</param>
        /// <param name="entityKey">The key of the entity to operate on.</param>
        /// <returns>An HTTP response message.</returns>
        [FunctionName("DurableFunctionsEntityCSharp_CounterHttpStart")]
        public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, Route = "Counter/{entityKey}")] HttpRequestMessage req,
        [DurableClient] IDurableEntityClient client,
        string entityKey)
        {
            // We create a new EntityId using the name of our entity and the key.
            var entityId = new EntityId(nameof(Counter), entityKey);

            // If the request method is a POST, we signal the entity to add 1.
            if (req.Method == HttpMethod.Post)
            {
                await client.SignalEntityAsync(entityId, "add", 1);
                // We send a 200 OK response.
                return req.CreateResponse(HttpStatusCode.OK);
            }

            // If the request method is not a POST, we read the state of the entity.
            EntityStateResponse<JToken> stateResponse = await client.ReadEntityStateAsync<JToken>(entityId);
            // We send a 200 OK response with the entity's state.
            return req.CreateResponse(HttpStatusCode.OK, stateResponse.EntityState);
        }

        [FunctionName(nameof(Counter))]
        /// <summary>
        /// Defines the behavior of the Counter entity function.
        /// </summary>
        /// <param name="context">The IDurableEntityContext object that provides access to the entity's state and operations.</param>
        public static void Counter([EntityTrigger] IDurableEntityContext context)
        {
            switch (context.OperationName.ToLowerInvariant())
            {
                case "add":
                    context.SetState(context.GetState<int>() + context.GetInput<int>());
                    break;
                case "reset":
                    context.SetState(0);
                    break;
                case "get":
                    context.Return(context.GetState<int>());
                    break;
            }
        }
    }
}