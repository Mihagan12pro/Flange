using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Detail_components
{
    internal abstract class Component
    {
        public readonly int Number;

        public readonly string Tittle;

        protected readonly Exception invalidValue;
        public Component(int number,object value,string tittle)
        {
            Number = number;
            Tittle = tittle;

            invalidValue = new Exception("Некорректные данные!");
        }
    }
}
