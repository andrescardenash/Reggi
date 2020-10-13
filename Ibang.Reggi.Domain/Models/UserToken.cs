using System;
using System.Collections.Generic;
using System.Text;

namespace Ibang.Reggi.Domain.Models
{
    public class UserToken
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public string UserId { get; set; }
    }
}
