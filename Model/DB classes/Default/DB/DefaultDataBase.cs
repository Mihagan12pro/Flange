using System;
using System.Collections.Generic;
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
            databaseFullName = MainExplorer.DataBaseExpl.DefaultSizes.DataBaseFullName;
            databaseTables = MainExplorer.DataBaseExpl.DefaultSizes.TableNames.ToArray();
        }
    }
}
