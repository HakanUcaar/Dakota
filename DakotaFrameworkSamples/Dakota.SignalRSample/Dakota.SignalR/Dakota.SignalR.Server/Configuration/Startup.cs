using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace Dakota.SignalR.Server.Configuration
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

            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            hubConfiguration.EnableJavaScriptProxies = false;
            AppBuilder.MapSignalR("/signalr", hubConfiguration);
        }
    }
}
