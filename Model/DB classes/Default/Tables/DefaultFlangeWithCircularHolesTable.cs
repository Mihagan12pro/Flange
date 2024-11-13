using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default.Tables
{
    internal abstract class DefaultFlangeWithCircularHolesTable : DefaultFlangeTable
    {
        protected double d1, d2;
        protected int n;


        public int N
        {
            get
            {
                return n;
            }
            protected set
            {
                n = value;
                OnPropertyChanged();
            }
        }
        public double D1
        {
            get
            {
                return d1;
            }
            protected set
            {
                d1 = value;
                OnPropertyChanged();
            }
        }
        public double D2
        {
            get
            {
                return d2;
            }
            protected set
            {
                d2 = value;
                OnPropertyChanged();
            }
        }


        public DefaultFlangeWithCircularHolesTable()
        {
            tableName = new DefaultDataBase().DatabaseTables[DefaultDataBase.AbstractFlangeCirculasHolesIndex];

            D1 =Convert.ToDouble(ExtractData()[0]);
            D2 = Convert.ToDouble(ExtractData()[1]);
            N = Convert.ToInt32(ExtractData()[2]);
        }
    }
}
