using System.Net;

namespace SitecoreHackathon23.Model
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public CookieCollection Cookies { get; set; }
    }
}
