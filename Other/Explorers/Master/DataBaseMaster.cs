using PathExplorerLibrary;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Other.Explorers.Master
{
    class DataBaseMaster : PathMaster
    {
        public readonly string DataBaseName, DataBaseFullName;

        protected List<string> tableNames = new List<string>();
        public List<string> TableNames
        {
            get
            {
                return tableNames;
            }
        }


        protected readonly Exception eConnectionError;




        public DataBaseMaster(string _FileName, string _FolderName) : base(_FileName, _FolderName)
        {
            DataBaseName = FileName;
            DataBaseFullName = "Data Source=" + FilePath;


            using (SQLiteConnection conn = new SQLiteConnection(DataBaseFullName))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("select name from sqlite_master where type = 'table'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(Convert.ToString(reader["name"]));
                        }
                        reader.Close();
                    }
                }
                conn.Close();
            }
        }
    }
}
