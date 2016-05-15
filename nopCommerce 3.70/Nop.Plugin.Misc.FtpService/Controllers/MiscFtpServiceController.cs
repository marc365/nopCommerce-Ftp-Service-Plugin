/*
 * (c) Nop Content 2016. All rights reserved.
 * User: github.com/marc365
 * Created: 2016
 */

using FtpPlugin.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Security;
using System.Web.Mvc;

namespace FtpPlugin.Controllers
{
    [AdminAuthorize]
    public class MiscFtpServiceController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly FtpServiceSettings _settings;

        public MiscFtpServiceController(
            ISettingService settingService,
            FtpServiceSettings settings)
        {
            _settingService = settingService;
            _settings = settings;
        }

        public ActionResult Configure()
        {
            var model = new ConfigureModel()
            {
                Server = _settings.Server,
                UserName = _settings.UserName,
                Password = _settings.Password
            };

            return View("~/Plugins/Misc.FtpService/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAntiForgery]
        public ActionResult Configure(ConfigureModel model)
        {
            _settings.Server = model.Server;
            _settings.UserName = model.UserName;
            _settings.Password = model.Password;
            
            _settingService.SaveSetting(_settings);
            SuccessNotification("Settings saved...");

            return View("~/Plugins/Misc.FtpService/Views/Configure.cshtml", model);
        }
    }
}