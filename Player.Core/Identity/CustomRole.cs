using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Player.Core.Identity
{
    public class CustomRole : IdentityRole<string, CustomUserRole>
    {
        public string Label { get; set; }
        public CustomRole()
        {
        }
        public CustomRole(string name)
        {
            this.Name = name;
        }

        public CustomRole(string label, string name)
        {
            this.Name = name;
            this.Label = label; ;
        }
    }
}
