/*
 * (c) Nop Content 2016. All rights reserved.
 * User: github.com/marc365
 * Created: 2016
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FtpPlugin.Services
{
    public partial class FtpService : IFtpService
    {

        #region Constructor

        private readonly FtpServiceSettings _settings;

        public FtpService(
            FtpServiceSettings settings)
        {
            _settings = settings;
        }

        #endregion

        public List<string> DirectoryList(string folder)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_settings.Server + folder);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<string> result = new List<string>();

            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }

            reader.Close();
            response.Close();
            return result;
        }

        public void Download(string filename, string destination)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_settings.Server + filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            StreamWriter writer = new StreamWriter(destination);
            writer.Write(reader.ReadToEnd());

            writer.Close();
            reader.Close();
            response.Close();
        }

        public void DownloadBinary(string filename, string destination)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_settings.Server + filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);
            request.UseBinary = true;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            using (BinaryReader reader = new BinaryReader(responseStream))
            {
                Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
                using (FileStream lxFS = new FileStream(destination, FileMode.Create))
                {
                    lxFS.Write(lnByte, 0, lnByte.Length);
                }
            }

            response.Close();
        }

        public void RemoveFile(string filename)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_settings.Server + filename);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }

        public void UploadFile(string source, string destination)
        {
            string filename = Path.GetFileName(source);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_settings.Server + filename);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);

            StreamReader sourceStream = new StreamReader(source);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());

            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();
            requestStream.Close();
            sourceStream.Close();
        }
    }
}
