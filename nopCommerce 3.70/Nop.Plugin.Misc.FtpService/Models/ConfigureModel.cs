/*
 * (c) Nop Content 2016. All rights reserved.
 * User: github.com/marc365
 * Created: 2016
 */

using Nop.Web.Framework.Mvc;

namespace FtpPlugin.Models
{
    public class ConfigureModel : BaseNopModel
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
