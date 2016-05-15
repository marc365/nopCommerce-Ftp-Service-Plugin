/*
 * (c) Nop Content 2016. All rights reserved.
 * User: github.com/marc365
 * Created: 2016
 */

using Nop.Core.Configuration;

namespace FtpPlugin
{
    public class FtpServiceSettings : ISettings
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}