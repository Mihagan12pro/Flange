using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flange.Other;
using Flange.Other.Abstract_classes_and_interfaces;
namespace Flange.Model.DB_classes.Default
{
    internal class DefaultDataBase : DataBase
    {
       
        public DefaultDataBase()
        {
            DatabaseFullName = MainExplorer.DataBaseExpl.DefaultSizes.DataBaseFullName;
            DatabaseTables = MainExplorer.DataBaseExpl.DefaultSizes.TableNames.ToArray();
        }
    }
}
