/*
 * (c) Nop Content 2016. All rights reserved.
 * User: github.com/marc365
 * Created: 2016
 */

using Nop.Core.Plugins;
using Nop.Services.Common;
using System.Web.Routing;

namespace FtpPlugin
{
    public class FtpService : BasePlugin, IMiscPlugin
    {
        public override void Install()
        {
            base.Install();
        }

        public override void Uninstall()
        {
            base.Uninstall();
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName,
            out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "MiscFtpService";
            routeValues = new RouteValueDictionary() { { "Namespaces", "FtpService.Controllers" }, { "area", null } };
        }
    }
}