using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace Player.BLogic.VkProvider
{
    public class VkProvider
    {
        private ulong appId;
        private string userName;
        private string password;
        private Settings scope;
        public VkProvider()
        {
            this.appId = 5196540;
            this.userName = "+380939375421";
            this.password = "sadilo";
            var authParams = new ApiAuthParams() { ApplicationId = this.appId, Password = this.password, Login = this.userName };
            var token = Resources.AppSettings.AUTH_TOKEN;
        }
    }
}
