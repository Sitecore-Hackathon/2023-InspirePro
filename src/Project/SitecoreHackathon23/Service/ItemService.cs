using SitecoreHackathon23.Model;
using System;
using System.IO;
using System.Net;

namespace SitecoreHackathon23.Service
{
    public class ItemService
    {
        public static readonly string xmCloudURL = Environment.GetEnvironmentVariable(Constant.EnvVariable.XMCloudDomainUrl);
        public static readonly string xmCloudAdminUserName = Environment.GetEnvironmentVariable(Constant.EnvVariable.XMCloudAdminUsername);
        public static readonly string xmCloudAdminPassword = Environment.GetEnvironmentVariable(Constant.EnvVariable.XMCloudAdminPassword);
        public ResponseModel RequestAPICall(string requestMethod, string url, string body, ResponseModel resp = null)
        {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest web = (HttpWebRequest)WebRequest.Create(url);
            web.AllowAutoRedirect = false;
            web.Method = requestMethod;
            web.ContentType = Constant.Header.Application_Json;
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
            var responseCookies = response.Cookies;           
            return new ResponseModel { Cookies = responseCookies, StatusCode = response.StatusCode };
        }

        public ResponseModel Authenticate()
        {
            var data = RequestAPICall(Constant.MethodBase.POST, $"{xmCloudURL}/sitecore/api/ssc/auth/login", "{\"domain\":\"sitecore\", \"username\":\"" + xmCloudAdminUserName + "\", \"password\":\"" + xmCloudAdminPassword + "\"}");
            Console.WriteLine($"{Constant.AuthenticateResponse}: {data.StatusCode}");
            Console.WriteLine($"{Constant.AuthenticateCookies}: {data.Cookies.Count}");
            return data;
        }
    }
}
