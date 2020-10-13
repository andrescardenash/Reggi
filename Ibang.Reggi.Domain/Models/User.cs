using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Ibang.Reggi.Domain.Models
{
    public class User : IdentityUser
    {
        public ICollection<Activity> Activity { get; set; }
    }
}
