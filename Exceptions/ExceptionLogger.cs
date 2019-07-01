using System;

namespace MLAutoFramework.Exceptions
{
    internal class ExceptionLogger
    {
        //Write exception in Log file
        public void WriteExceptionToFile(string folderPath, Exception e)
        {
            string message = null;
            //byte[] data = null;
           
            //if (MLException.IsMLException(e))
            //{
            //    MLException MLEx = (e as MLException);

            //    string str = MLEx.AsSoapDetail.OuterXml;
            //    data = ASCIIEncoding.ASCII.GetBytes(str);
            //    message = "Message: " + e.Message + "\r\nSource: " + e.Source
            //        + "\r\nBottom ML Exception: " + MLEx.BottomMLExceptionSummary.Message
            //        + "\r\nTop non ML Exception: " + MLEx.TopNonMLExceptionSummary.Message
            //        +"\r\n-----------------------------------------------------------------------\r\n"
            //        +str;
            //}
            //else
            //{
            //    message = "Message: " + e.Message + "\r\nSource: " + e.Source;
            //}
            new Helpers.FileHelper(folderPath).WriteToFile(message, Helpers.LogType.Exception);
        }
    }
}
