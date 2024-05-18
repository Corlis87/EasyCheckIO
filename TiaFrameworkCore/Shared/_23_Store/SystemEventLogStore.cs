using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Serilog;
using SqlSugar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_Models;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.Shared._23_Store
{
    public class SystemEventLogStore : IStore<List<EventLogData>>
    {
        #region Field
        private const int PAGESIZE = 10;
        private int pageIndex;
        private DataTable Logs;


        #endregion

        #region Properties

        #region LogList

        private List<EventLogData> LogsList;
        public List<EventLogData> Entity => LogsList;

        #endregion

        #region TotalCount

        private int totalRecords;
        public string TotalRecords => totalRecords.ToString();
        #endregion

        #region PageNumText
        private string pageNumText;
        public string PageNumText => PageNumText;
        #endregion;

        #endregion

        #region Method
        public void ReadEventLogDatabase(string level)
        {
            var result = new DirectoryInfo(FileSystem.AppDataDirectory).GetFiles();
            var connectionstring = "Data Source =" + FileSystem.AppDataDirectory + "/Project_Logs.db";
            try
            {
                SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = connectionstring,
                    DbType = SqlSugar.DbType.Sqlite,
                    IsAutoCloseConnection = true,
                });
                var conditions = new List<IConditionalModel>();
                if (!(level == "All") && !(string.IsNullOrWhiteSpace(level)))
                {
                    conditions.Add(new ConditionalModel
                    {
                        FieldName = "Level",
                        ConditionalType = ConditionalType.Like,
                        FieldValue = level
                    });
                }
                LogsList = db.Queryable<EventLogData>().AS("Project_Logs").Where(conditions).OrderBy(t=>t.id,OrderByType.Desc).ToPageList(pageIndex, PAGESIZE, ref totalRecords);
                pageIndex = (totalRecords == 0) ? pageIndex = 0 : pageIndex;
                pageNumText = $"Page {pageIndex} of {(int)Math.Ceiling((double)totalRecords / PAGESIZE)}";
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
        private void ClearEventLogDatabase()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Data Source =" + FileSystem.AppDataDirectory + "/Project_Logs.db",
                DbType = SqlSugar.DbType.Sqlite,
                IsAutoCloseConnection = true,
            });
            db.Deleteable<EventLogData>().AS("Project_Logs").ExecuteCommand();
        }
        public void Clear()
        {
            ClearEventLogDatabase();
            ReadEventLogDatabase("All");
        }
        public void NextPage(string level)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / PAGESIZE);
            if (pageIndex < totalPages)
            {
                pageIndex++;
                ReadEventLogDatabase(level);
            }
        }
        public void PreviewPage(string level)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                ReadEventLogDatabase(level);
            }
        }

        #endregion
    }
}