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

namespace SitecoreHackathon23
{
    public static class Reject
    {
        private static readonly string xmCloudURL = Environment.GetEnvironmentVariable("XM_Cloud_Domain_Url");
        private static readonly string xmCloudAdminUserName = Environment.GetEnvironmentVariable("XM_Cloud_Admin_Username");
        private static readonly string xmCloudAdminPassword = Environment.GetEnvironmentVariable("XM_Cloud_Admin_Password");
        [FunctionName("Reject")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string itemID = req.Query["itemid"];

            //authenticate environment
            Resp data = Authenticate();

            //approve item
            var resp = RejectWorkflow(data, itemID);













            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data1 = JsonConvert.DeserializeObject(requestBody);


            string responseMessage = string.IsNullOrEmpty(itemID)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {itemID}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        private static Resp RequestAPICall(string requestMethod, string url, string body, Resp resp = null)
        {
            string jsonResponse = string.Empty;
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest web = (HttpWebRequest)WebRequest.Create(url);
            web.AllowAutoRedirect = false;
            web.Method = requestMethod;
            web.ContentType = "application/json";
            web.CookieContainer = cookies;
            if (resp != null)
                web.CookieContainer.Add(resp.Cookies);
            using (var streamWriter = new StreamWriter(web.GetRequestStream()))
            {
                string json = body;
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            HttpWebResponse response = (HttpWebResponse)web.GetResponse();
            var responseCookies = response.Cookies;//cookies.GetCookies(new Uri(url)).Cast<Cookie>();
            //jsonResponse = GetJSONResponse(response);            
            return new Resp { Cookies = responseCookies, StatusCode = response.StatusCode };
        }

        public class Resp
        {
            public HttpStatusCode StatusCode { get; set; }
            public CookieCollection Cookies { get; set; }
        }
        private static Resp ApproveWorkFlow(Resp authenticateResponse, string itemid)
        {
            var data = RequestAPICall("PATCH", $"{xmCloudURL}/sitecore/api/ssc/item/{itemid}?database=master", "{\"__Workflow state\": \"{FCA998C5-0CC3-4F91-94D8-0A4E6CAECE88}\"}", authenticateResponse);
            Console.WriteLine($"Approved Response: {data.StatusCode}");
            Console.WriteLine($"Approved Cookies: {data.Cookies.Count}");
            return data;
        }
        private static Resp Authenticate()
        {
            var data = RequestAPICall("POST", $"{xmCloudURL}/sitecore/api/ssc/auth/login", "{\"domain\":\"sitecore\", \"username\":\"" + xmCloudAdminUserName + "\", \"password\":\"" + xmCloudAdminPassword + "\"}");
            Console.WriteLine($"Authenticate Response: {data.StatusCode}");
            Console.WriteLine($"Authenticate Cookies: {data.Cookies.Count}");
            return data;
        }
        private static Resp RejectWorkflow(Resp authenticateResponse, string itemid)
        {
            var data = RequestAPICall("PATCH", $"{xmCloudURL}/sitecore/api/ssc/item/{itemid}?database=master", "{\"__Workflow state\": \"{190B1C84-F1BE-47ED-AA41-F42193D9C8FC}\"}", authenticateResponse);
            Console.WriteLine($"Rejected Response: {data.StatusCode}");
            Console.WriteLine($"Rejected Cookies: {data.Cookies.Count}");
            return data;
        }
    }
}
