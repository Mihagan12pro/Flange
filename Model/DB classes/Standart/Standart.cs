﻿using Flange.Databases.Classes.Standart.Data_storages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flange.Other;
namespace Flange.Databases.Classes.Standart
{
    internal abstract class Standart
    {
        protected  string database;

        
      


        protected ObservableCollection<DataStorage> data;

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

        protected abstract void SelectfromDatabase();
    }
}
