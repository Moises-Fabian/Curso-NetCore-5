using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWEB.Utility
{
    public class Resource
    {
        public const string ApiBaseUrl = "https://localhost:44381/";
        public const string ProductAPIUrl = ApiBaseUrl + "api/Product/";
        public const string RegisterAPIUrl = ApiBaseUrl + "api/user/register";
        public const string LoginAPIUrl = ApiBaseUrl + "api/user/login";
        public const string ContentType = "application/json";
    }
}
