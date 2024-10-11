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

        protected readonly Exception eConnectionError;

        public DataBaseLocation(string _FileName, string _FolderName) : base(_FileName, _FolderName)
        {
            DataBaseName = FileName;
            DataBaseFullName = "Data Source=" + FilePath;

            eConnectionError = new Exception($"The application can't connect to the {DataBaseName}!");

            try
            {
                using (SQLiteConnection tryConnect = new SQLiteConnection(DataBaseFullName))
                {
                    tryConnect.Open();
                    tryConnect.Close();
                }
            }
            catch
            {
                throw eConnectionError;
            }
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
                return standartSizes.DataBaseFullName;
            }
        }

        public DataBaseExplorer(DataBaseLocation defaultSizes,DataBaseLocation standartSizes):base(defaultSizes)
        {
            this.defaultSizes = defaultSizes;
            this.standartSizes = standartSizes;
        }
    }
}
