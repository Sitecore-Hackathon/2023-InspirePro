namespace SitecoreHackathon23
{
    public class Constant
    {
        public static readonly string ApprovedResponse = "Approved response";
        public static readonly string CookiesCreated = "Cookies created";

        public static readonly string AuthenticateResponse = "Authenticate response";
        public static readonly string RejectedResponse = "Rejected response";
        public static readonly string RejectedCookies = "Rejected cookies";
        public static readonly string AuthenticateCookies = "Authenticate cookies";

        public class MethodBase
        {
            public static readonly string POST = "POST";
            public static readonly string PATCH = "PATCH";
        }
        public class Header
        {
            public static readonly string Application_Json = "application/json";
        }
        public class EnvVariable
        {
            public static readonly string XMCloudDomainUrl = "XM_Cloud_Domain_Url";
            public static readonly string XMCloudAdminUsername = "XM_Cloud_Admin_Username";
            public static readonly string XMCloudAdminPassword = "XM_Cloud_Admin_Password";
        }

        public class Message
        {
            public static readonly string ItemNotFound = "Item not found."; 
            public static readonly string ItemUpdatedSuccessfully = "Item with id {0} updated successfully.";
        }
    }
}
