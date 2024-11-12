using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathExplorerLibrary;
using System.Data.SQLite;
namespace Flange.Other
{
    class DataBaseLocation : PathMaster
    {
        public readonly string DataBaseName,DataBaseFullName;

        protected List<string> tableNames = new List<string>();

        protected readonly Exception eConnectionError;




        public DataBaseLocation(string _FileName, string _FolderName) : base(_FileName, _FolderName)
        {
            DataBaseName = FileName;
            DataBaseFullName = "Data Source=" + FilePath;


            using (SQLiteConnection conn = new SQLiteConnection(DataBaseFullName))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("select name from sqlite_master where type = 'table'",conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            tableNames.Add(Convert.ToString(reader["name"]));
                        }
                        reader.Close();
                    }
                }
                conn.Close();
            }

            //eConnectionError = new Exception($"The application can't connect to the {DataBaseName}!");

            //try
            //{
            //    using (SQLiteConnection tryConnect = new SQLiteConnection(DataBaseFullName))
            //    {
            //        tryConnect.Open();
            //        tryConnect.Close();
            //    }
            //}
            //catch
            //{
            //    throw eConnectionError;
            //}
        }
    }
    internal class DataBaseExplorer : Explorer
    {
        private readonly DataBaseLocation defaultSizes,standartSizes;
       
    
        public string StandartSizesName
        {
            get
            {
                return standartSizes.DataBaseName;
            }
        }
        public string StandartSizesFullName
        {
            get
            {
                return standartSizes.DataBaseFullName;
            }
        }



        public string DefaultSizesName
        {
            get
            {
                return defaultSizes.DataBaseName;
            }
        }

        public string DefaultSizesFullName
        {
            get
            {
                return defaultSizes.DataBaseFullName;
            }
        }

        public DataBaseExplorer(DataBaseLocation defaultSizes,DataBaseLocation standartSizes):base(defaultSizes)
        {
            this.defaultSizes = defaultSizes;
            this.standartSizes = standartSizes;
        }
    }
}
