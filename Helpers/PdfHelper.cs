using System;
using System.Text;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OpenQA.Selenium;
using GemBox.Document;
using System.Windows.Forms;

namespace MLAutoFramework.Helpers
{
    public static class PdfHelper
    {
        //pathToFile should be the absolute or relative path to the pdf file with Filename.pdf 
        //for example - D://test//Test.pdf
        //This will get text of all pages from pdf
        public static string GetAllTextFromPDF(this IWebDriver driver, string pathToFile)
        {
            try
            {
                StringBuilder text = new StringBuilder();
                using (PdfReader reader = new PdfReader(pathToFile))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
                return text.ToString();
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }


        //This will get text of desired page from pdf
        public static string GetDefinedPageTextFromPDF(this IWebDriver driver, string pathToFile, int pageN)
        {
            try
            {
                StringBuilder text = new StringBuilder();
                using (PdfReader reader = new PdfReader(pathToFile))
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, pageN));
                return text.ToString();
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }

        //This will upload file where input field is available
        //Please add file name and extension in file path
        public static void UploadDocument(this IWebElement element, string filePath)
        {
            try
            {
                element.SendKeys(filePath);
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }


        public static void VerifySpecificTextInPDF(string filepath, string pattern)
        {
            // If using Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            DocumentModel document = DocumentModel.Load(filepath);

            StringBuilder sb = new StringBuilder();

            // Read PDF file's document properties.
            sb.AppendFormat("Author: {0}", document.DocumentProperties.BuiltIn[BuiltInDocumentProperty.Author]).AppendLine();
            sb.AppendFormat("DateContentCreated: {0}", document.DocumentProperties.BuiltIn[BuiltInDocumentProperty.DateLastSaved]).AppendLine();

            // Sample's input parameter.
            //string pattern = @"(?<WorkHours>\d+)\s+(?<UnitPrice>\d+\.\d{2})\s+(?<Total>\d+\.\d{2})";
            Regex regex = new Regex(pattern);

            int row = 0;
            StringBuilder line = new StringBuilder();

            // Read PDF file's text content and match a specified regular expression.
            foreach (Match match in regex.Matches(document.Content.ToString()))
            {
                line.Length = 0;
                line.AppendFormat("Result: {0}: ", ++row);

                // Either write only successfully matched named groups or entire match.
                bool hasAny = false;
                for (int i = 0; i < match.Groups.Count; ++i)
                {
                    string groupName = regex.GroupNameFromNumber(i);
                    Group matchGroup = match.Groups[i];
                    if (matchGroup.Success && groupName != i.ToString())
                    {
                        line.AppendFormat("{0}= {1}, ", groupName, matchGroup.Value);
                        hasAny = true;
                    }
                }

                if (hasAny)
                    line.Length -= 2;
                else
                    line.Append(match.Value);

                sb.AppendLine(line.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
