using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flange.Other;
using Flange.Model;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Flange.Databases.Classes.Standart.Data_storages;
using Flange.Databases.Classes.Standart;
namespace Flange.ViewModel.Tables
{
    internal abstract class Table
    {
        // public readonly string 

        protected readonly string database;

        protected  ObservableCollection<DataStorage>data;

        public ObservableCollection<DataStorage> Data 
        { 
            get
            {
                return data;
            }
            protected set 
            {
                data = value;
            } 
        }

        public Table()
        {
            database = MainExplorer.DataBaseExpl.DefaultSizesFullName;
        }
    }
    class FreeSimpleTable:Table
    {
        public FreeSimpleTable()
        {
            Data = new StandartFreeSimpleFlange().Data;
        }
    }
}
