using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

namespace Dakota.Server.SignalR.Configuration
{
    public class Startup
    {
        public void Configuration(IAppBuilder AppBuilder)
        {
            AppBuilder.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR(new HubConfiguration { EnableJSONP = true });
            });

            //AppBuilder.MapSignalR();
        }
    }
}
