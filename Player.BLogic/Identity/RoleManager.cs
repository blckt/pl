using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Player.Core.Identity;

namespace Player.BLogic.Identity
{
    public class RoleManager : RoleManager<CustomRole, string>
    {
        public RoleManager(IRoleStore<CustomRole, string> store) : base(store)
        {
        }
    }
}
