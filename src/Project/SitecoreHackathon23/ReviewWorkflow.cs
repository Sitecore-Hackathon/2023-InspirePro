using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SitecoreHackathon23.Model;
using System.Collections.Generic;
using System.Linq;
using MessageCardModel.Actions;
using MessageCardModel.Actions.OpenUri;
using MessageCardModel;
using System.Text;
using System.Net.Http;

namespace SitecoreHackathon23
{
    public static class ReviewWorkflow
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly string AzureFunction_Approve_URL = Environment.GetEnvironmentVariable("AzureFunction_Approve_URL");
        private static readonly string AzureFunction_Reject_URL = Environment.GetEnvironmentVariable("AzureFunction_Reject_URL");
        [FunctionName("ReviewWorkflow")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Process the webhook request and get the sitecore item data
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            WorkflowModal data = JsonConvert.DeserializeObject<WorkflowModal>(requestBody);
            string itenname = data?.item?.Name;
            string itemid = data?.item?.Id;
            List<VersionedField> ver = data?.item?.VersionedFields;
            VersionedField a = ver.FirstOrDefault(x => x.Id == "3e431de1-525e-47a3-b6b0-1ccbec3a8c98");
            string workflowval = a.Value;


            // Create Team's Message
            string teammessage = "{\"@type\":\"MessageCard\",\"@context\":\"http://schema.org/extensions\",\"themeColor\":\"0076D7\",\"summary\":\"Sitecore Hackathon'23-Team InspirePro\",\"sections\":[{\"activityTitle\":\"Review Work flow Item\",\"activitySubtitle\":\"On Project Tango\",\"activityImage\":\"https://raw.githubusercontent.com/prashant162/Spaceshooter/master/sitecore.png\",\"facts\":[{\"name\":\"Item Name\",\"value\":\"" + itenname + "\"},{\"name\":\"Item ID\",\"value\":\"" + itemid + "\"},{\"name\":\"Current Workflow State\",\"value\":\"Awaiting for review\"}],\"markdown\":true}],\"potentialAction\":[{\"@type\":\"OpenUri\",\"name\":\"Approve\",\"targets\":[{\"os\":\"default\",\"uri\":\""+AzureFunction_Approve_URL+"&itemid=" + itemid + "\"}]},{\"@type\":\"OpenUri\",\"name\":\"Reject\",\"targets\":[{\"os\":\"default\",\"uri\":\""+AzureFunction_Reject_URL+"&itemid=" + itemid + "\"}]}]}";
            
            dynamic data2 = JsonConvert.DeserializeObject(teammessage);

            // Send mesasage to Teams using Webhook
            string TeamsWebhookUrl = Environment.GetEnvironmentVariable("Teams_Webhook_Url");
            var content = new StringContent(JsonConvert.SerializeObject(data2), Encoding.UTF8, "application/json");
            await HttpClient.PostAsync(TeamsWebhookUrl, content);


            string responseMessage = string.IsNullOrEmpty(itenname)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {itenname}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
