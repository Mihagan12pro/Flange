using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flange.Kompas.Modeling
{
    internal class SimpleFlange : AbstractFlange
    {
       


        protected double  db;
      

        public SimpleFlange(string D, string D1, string D2, string Db, string H, string CountOfHoles) : base(D,D1,D2,H,CountOfHoles)
        {
            if (IsCorrect(D,out d) && IsCorrect(D1,out d1)&& IsCorrect(D2,out d2) && IsCorrect(Db,out db) && IsCorrect(H, out h)&&IsCorrect(CountOfHoles,out countOfHoles))
            {
                Build();
            }
            MessageBox.Show("Некорректный ввод!");
            
        }


  
    }
}
