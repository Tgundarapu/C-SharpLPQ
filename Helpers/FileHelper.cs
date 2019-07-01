using System;
using System.IO;


namespace MLAutoFramework.Helpers
{
    internal class FileHelper
    {

        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;
        private string m_FolderPath = string.Empty;
        private string m_FileName = string.Empty;
        public FileHelper(string folderPath)
        {
            m_FolderPath = folderPath;
        }
        internal void WriteToFile(String message,LogType logType,string filename=null)
        {
            try
            {
                zGetFileName(logType, filename);

                if (Directory.Exists(m_FolderPath))
                {
                    _streamw = File.AppendText(m_FolderPath + "_" + m_FileName + _logFileName + ".log");
                }
                else
                {
                    Directory.CreateDirectory(m_FolderPath);
                    _streamw = File.AppendText(m_FolderPath + "_" + _logFileName + ".log");
                }
                zWrite(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void zGetFileName(LogType logtype, string filename)
        {
            switch (logtype)
            {
                case LogType.Message:
                   m_FileName = filename;
                    break;
                case LogType.Exception:
                    m_FileName = "Exception";
                    break;
                default:
                    m_FileName = string.Empty;
                    break;
            }
        }
        private void zWrite(string logMessage)
        {
            _streamw = File.AppendText(m_FolderPath + m_FileName + "_" + _logFileName + ".log");
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMessage);
            _streamw.Flush();
        }


    }
}
