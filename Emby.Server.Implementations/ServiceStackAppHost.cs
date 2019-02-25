using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Funq;
using ServiceStack;

namespace Emby.Server.Implementations
{
    public class ServiceStackAppHost : AppHostBase
    {
        public ServiceStackAppHost(string serviceName, params Assembly[] assembliesWithServices) : base(serviceName, assembliesWithServices)
        {
        }

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                ReturnsInnerException = true,
            });
        }
    }
}
