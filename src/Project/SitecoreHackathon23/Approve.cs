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
    public class Approve : ItemService
    {

        [FunctionName("Approve")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string itemID = req.Query["itemid"];

            //authenticate environment
            ResponseModel data = Authenticate();

            //approve item
            var resp = ApproveWorkFlow(data, itemID);
            await new StreamReader(req.Body).ReadToEndAsync();

            string responseMessage = string.IsNullOrEmpty(itemID) ? Constant.Message.ItemNotFound : string.Format(Constant.Message.ItemUpdatedSuccessfully, itemID);

            return new OkObjectResult(responseMessage);
        }

        private ResponseModel ApproveWorkFlow(ResponseModel authenticateResponse, string itemid)
        {
            var data = RequestAPICall(Constant.MethodBase.PATCH, $"{xmCloudURL}/sitecore/api/ssc/item/{itemid}?database=master", "{\"__Workflow state\": \"{FCA998C5-0CC3-4F91-94D8-0A4E6CAECE88}\"}", authenticateResponse);
            Console.WriteLine($"{Constant.ApprovedResponse}: {data.StatusCode}");
            Console.WriteLine($"{Constant.CookiesCreated}: {data.Cookies.Count}");
            return data;
        }
       
    }
}
