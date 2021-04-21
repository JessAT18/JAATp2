namespace JAATfncConsumidor
{
    using System;
    using JAATfncConsumidor.Models;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public static class Function1
    {

        [FunctionName("Function1")]
        public static async Task RunAsync(
            [ServiceBusTrigger(
                "jaatqueue",
                Connection = "jaatqueueConn"
            )]string myQueueItem,

            [CosmosDB(
                databaseName:"JAATdb",
                collectionName:"ModelParcial",
                ConnectionStringSetting = "strCosmos"
            )] IAsyncCollector<object> datos,

            ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<ModelParcial>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No es posible insertar datos: {ex.Message}");
            }
        }

    }
}
