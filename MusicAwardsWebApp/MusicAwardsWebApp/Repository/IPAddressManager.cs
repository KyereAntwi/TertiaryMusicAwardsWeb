using Microsoft.AspNetCore.Http;
using System;

namespace MusicAwardsWebApp.Repository
{
    public class IPAddressManager : IIPAddressManager
    {
        private IHttpContextAccessor _accessor;
        public IPAddressManager(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetIPAddress()
        {
            try
            {
                return _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
