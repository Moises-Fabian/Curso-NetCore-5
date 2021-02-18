using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class UserTokenDTO
    {
        public string Token { get; set; }

        public string UserName { get; set; }

        public List<string> Roles { get; set; }
    }
}
