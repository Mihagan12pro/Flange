using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Other.Abstract_classes_and_interfaces
{
    internal class DataBase
    {
        public string DatabaseFullName {  get; protected set; }
        public string[] DatabaseTables { get; protected set; }


        public static readonly int AbstractFlangeIndex = 0;
        public static readonly int AbstractFlangeCirculasHolesIndex = 1;
        public static readonly int FreeFlangeIndex = 2;
        public static readonly int FlatFlangeIndex = 3;
        public static readonly int BlindFlangeIndex = 4;

    }
}
