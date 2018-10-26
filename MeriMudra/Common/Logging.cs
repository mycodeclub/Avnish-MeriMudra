using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace MeriMudra.Common
{
    public class Logging
    {
        public void DbCallLog(string controller = "", string actionMethod = "", string timeTaken = "", string comment = "")
        {
            StringBuilder sb = new StringBuilder();
            var path = GetFilePath("DbCallLog.csv");
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                WriteLog(path, sb.Append("controller,actionMethod,timeTaken,comment").ToString());
            }
            sb.Append(controller + "," + actionMethod + "," + timeTaken + "," + comment);
            WriteLog(path, sb.ToString());
        }

        protected void WriteLog(string path, string log)
        {
            try
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(log);
                    tw.Close();
                }
            }
            catch { }
        }
        protected static string GetFilePath(string path)
        {
            var dir = Path.GetDirectoryName(typeof(Logging).Assembly.CodeBase);
            dir = dir.Replace("\\", "/");
            return dir.Substring(6) + "/../" + path;
            //return dir;
            //   var dir = "~/Common"; return dir;
        }
    }
}