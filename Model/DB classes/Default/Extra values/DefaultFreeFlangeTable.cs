using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default.Tables
{
    public class DefaultFreeFlangeTable : DefaultFlangeWithCircularHolesTable
    {
        protected double db;
        public double Db
        {
            get
            {
                return db;
            }
            protected set
            {
                db = value;
                OnPropertyChanged();
            }
        }
        public DefaultFreeFlangeTable()
        {
            tableName = new DefaultDataBase().DatabaseTables[DefaultDataBase.AbstractFlangeCirculasHolesIndex];

            Db = Convert.ToDouble(ExtractData()[0]);
        }
    }
}
