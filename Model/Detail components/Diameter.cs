using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Detail_components
{
    internal class Diameter : Component
    {
        private double diameter;
        public double _Diameter
        {
            get
            {
                return diameter;
            }
            private set
            {
                diameter = value;
            }
        }
        public Diameter(int number, object value, string tittle) : base(number, value, tittle)
        {
            if (value is double)
            {
                _Diameter = Convert.ToDouble(value);
            }
            else
            {
                throw invalidValue;
            }
        }
    }
}
