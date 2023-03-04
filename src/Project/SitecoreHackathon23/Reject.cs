using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using SitecoreHackathon23.Service;
using SitecoreHackathon23.Model;

namespace SitecoreHackathon23
{
    public class Reject : ItemService
    {
        [FunctionName("Reject")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string itemID = req.Query["itemid"];

            //authenticate environment
            ResponseModel data = Authenticate();

            //approve item
            var response = RejectWorkflow(data, itemID);

            await new StreamReader(req.Body).ReadToEndAsync();

            string responseMessage = string.IsNullOrEmpty(itemID) ? Constant.Message.ItemNotFound : string.Format(Constant.Message.ItemUpdatedSuccessfully, itemID);

            return new OkObjectResult(responseMessage);
        }

        private ResponseModel RejectWorkflow(ResponseModel authenticateResponse, string itemid)
        {
            var data = RequestAPICall(Constant.MethodBase.PATCH, $"{xmCloudURL}/sitecore/api/ssc/item/{itemid}?database=master", "{\"__Workflow state\": \"{190B1C84-F1BE-47ED-AA41-F42193D9C8FC}\"}", authenticateResponse);
            Console.WriteLine($"{Constant.RejectedResponse}: {data.StatusCode}");
            Console.WriteLine($"{Constant.RejectedCookies}: {data.Cookies.Count}");
            return data;
        }
    }
}
