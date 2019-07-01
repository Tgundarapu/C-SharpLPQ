using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace MLAutoFramework.Helpers
{
    public class ExcelHelper
    {
        private static List<ExcelTableDataCollection> _dataCol = new List<ExcelTableDataCollection>();

        public static List<ExcelTableDataCollection> DataCol
        {
            get
            {
                return _dataCol;
            }
        }

        /// <summary>
        /// Storing all the excel values in to the in-memory collections
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollection(string fileName)
        {
            try
            {
                DataTable table = ExcelToDataTable(fileName);
                _dataCol.Clear();
                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        ExcelTableDataCollection dtTable = new ExcelTableDataCollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };
                        //Add all the details for each row
                        _dataCol.Add(dtTable);
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                throw;
            }
        }


        /// <summary>
        /// This method is used to read row from excel.
        /// </summary>
        /// <param name="rowIndex">row index of the row to be read</param>
        /// <returns></returns>
        public static List<ExcelTableDataCollection> ReadRowfromExcel(int rowIndex)
        {
            try
            {
                List<ExcelTableDataCollection> dataFromExcel = (from colData in ExcelHelper.DataCol
                                                                where colData.rowNumber == rowIndex
                                                                select colData).ToList();

                return dataFromExcel;
            }
            catch (Exception e)
            {
                LogHelper.Write("ERROR :: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// This method is used to read row from excel.
        /// </summary>
        /// <param name="rowIndex">row index of the row to be read</param>
        /// <returns></returns>
        public static List<ExcelTableDataCollection> ReadRowfromExcel(string patientName)
        {
            try
            {
                List<int> rowIndexes = (from colData in ExcelHelper.DataCol
                                        where colData.colValue == patientName
                                        select colData.rowNumber).ToList();

                List<ExcelTableDataCollection> dataFromExcel = (from colData in ExcelHelper.DataCol
                                                                where rowIndexes.Contains(colData.rowNumber)
                                                                select colData).ToList();

                return dataFromExcel;
            }
            catch (Exception e)
            {
                LogHelper.Write("ERROR :: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Reading all the datas from Excelsheet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string fileName)
        {
            try
            {
                using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {//open file and returns as Stream
                 //FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                 //Createopenxmlreader via ExcelReaderFactory
                 //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
                 //Set the First Row as Column Name
                 // excelReader.IsFirstRowAsColumnNames = true;
                 //Return as DataSet
                 //DataSet result = excelReader.AsDataSet();
                 //Get all the Tables
                 //DataTableCollection table = result.Tables;
                 //Store it in DataTable
                 //DataTable resultTable = table["Sheet1"];
                 //return
                    return new DataTable();//resultTable;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to Read cell from excel
        /// </summary>
        /// <param name="rowIndex">RowIndex</param>
        /// <param name="columnName">ColumnName</param>
        /// <returns></returns>
        public static string ReadCellFromExcel(int rowIndex, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowIndex
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                Console.WriteLine("ERROR:: " + e.Message);
                return null;
            }
        }


        public static List<string> ReadColumnFromExcel(string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                var data = (from colData in _dataCol
                            where colData.colName == columnName && !string.IsNullOrEmpty(colData.colValue)
                            select colData.colValue);

                return data.ToList<string>();
            }
            catch (Exception e)
            {
                LogHelper.LogException(e);
                Console.WriteLine("ERROR:: " + e.Message);
                return null;
            }
        }
    }


    [Serializable]
    public class ExcelTableDataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}

