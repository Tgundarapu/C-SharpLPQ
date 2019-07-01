using System;
using System.Data;
using Granite.DataAccess;
using System.Data.Common;
using System.Collections.Generic;
using System.Collections;
using MLAutoFramework.Config;

namespace MLAutoFramework.Helpers
{
    public class DataBaseHelper
    {
        DbParameters m_Dbp;
        public DataBaseHelper(string connectionString)
        {
            m_Dbp = new DbParameters();
            m_Dbp.ConnectionString = connectionString;
            m_Dbp.KeepConnectionOpen = false;
            m_Dbp.LocalOnly = false;
            m_Dbp.ReadOnly = false;
            m_Dbp.Timeout = 15;
        }

        public DataTable GetDataTableFromQuery(string sql)
        {
            DataTable dataTable = null;
            using (DataBrokerSql dataBroker = new DataBrokerSql(m_Dbp))
            {
                dataTable = dataBroker.GetDataTable(sql);
            }
            return dataTable;
        }


        public DbDataReader GetDataReader(string sql)
        {
            DataBrokerSql dataBroker = new DataBrokerSql(m_Dbp);

            return dataBroker.GetDataReader(sql);

        }

        public object ExecuteScalar(string sql)
        {
            using (DataBrokerSql dataBroker = new DataBrokerSql(m_Dbp))
            {
                return dataBroker.GetScalar(sql);
            }
        }

        public static void ExecuteStoredProc(Dictionary<string, Tuple<ParameterDirection, string, SqlDbType, dynamic>> storedProcParameters, string storedProcName)
        {

            ArrayList inList = new ArrayList();
            try
            {
                DbParameters databaseParameters = new DbParameters()
                {
                    ConnectionString = Settings.DBConnectionString,
                    KeepConnectionOpen = false,
                    LocalOnly = false,
                    ReadOnly = false,
                    Timeout = 15
                };

                using (DataBrokerSql dataBroker = new DataBrokerSql(databaseParameters))
                {
                    foreach (var item in storedProcParameters.Keys)
                    {
                        DataBrokerSql.AddParameter(inList, storedProcParameters[item].Item1, storedProcParameters[item].Item2, storedProcParameters[item].Item3, storedProcParameters[item].Item4);
                    }

                    dataBroker.ExecStoreProcedure(storedProcName, inList, null);
                }
            }

            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //throw ex;
            }

        }


        //public static void AssertTableDataComparison(List<HtmlTableDataCollection> expected)
        //{
        //    try
        //    {
        //        for (int i = 0; i < _tableDatacollections.Count; i++)
        //        {
        //            Assert.AreEqual(expected[i].ColumnName, _tableDatacollections[i].ColumnName);
        //            Assert.AreEqual(expected[i].ColumnValue, _tableDatacollections[i].ColumnValue);
        //            LogHelper.Write("Data comparision success");
        //        }
        //    }
        //    catch (AssertionException)
        //    {
        //        LogHelper.Write("Data comparision fail");
        //        Assert.Fail("DataComparisonFail");
        //    }
        //}
        /// <summary>
        /// This method uses MasterDBConnectionString from app.config for managing snapshots.
        /// Database is picked from DBName key present app.config
        /// To take DB Snapshot, EnableDBSnapshot setting should be set to true in app.config
        /// </summary>
        /// <param name="isSnaphotToBeTaken">true: Take snapshot, false: Restore snapshot</param>
        public static void ManageDBSnapshot(bool isSnaphotToBeTaken)
        {
            int snapShot = isSnaphotToBeTaken ? 0 : 1;
            ArrayList inList = new ArrayList();
            try
            {
                if (Settings.EnableDBSnapshot)
                {
                    DbParameters databaseParameters = new DbParameters()
                    {
                        ConnectionString = Settings.MasterDBConnectionString,
                        KeepConnectionOpen = false,
                        LocalOnly = false,
                        ReadOnly = false,
                        Timeout = 15
                    };

                    using (DataBrokerSql dataBroker = new DataBrokerSql(databaseParameters))
                    {

                        DataBrokerSql.AddParameter(inList, ParameterDirection.Input, "RestoreSnapshot", SqlDbType.Bit, snapShot);
                        DataBrokerSql.AddParameter(inList, ParameterDirection.Input, "DatabaseName", SqlDbType.VarChar, Settings.DBName);
                        dataBroker.ExecStoreProcedure("[dbo].[CreateDBSnapshot_AnyDB]", inList, null);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //throw ex;
            }
        }

        public static void ExecuteQuery(string Query)
        {
            try
            {
                DbParameters databaseParameters = new DbParameters()
                {
                    ConnectionString = Settings.DBConnectionString,
                    KeepConnectionOpen = false,
                    LocalOnly = false,
                    ReadOnly = false,
                    Timeout = 15
                };
                using (DataBrokerSql dataBroker = new DataBrokerSql(databaseParameters))
                {
                    dataBroker.ExecSQL(Query);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                //throw ex;
            }
        }
    }


}

