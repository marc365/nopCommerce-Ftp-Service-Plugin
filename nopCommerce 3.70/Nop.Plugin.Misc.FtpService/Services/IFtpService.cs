/*
 * (c) Nop Content 2016. All rights reserved.
 * User: github.com/marc365
 * Created: 2016
 */

using System.Collections.Generic;

namespace FtpPlugin.Services
{
    public partial interface IFtpService
    {
        List<string> DirectoryList(string folder);

        void Download(string filename, string destination);

        void DownloadBinary(string filename, string destination);

        void RemoveFile(string filename);

        void UploadFile(string source, string destination);
    }
}
