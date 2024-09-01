using Kompas6API5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flange.Kompas.Modeling
{
    internal class SimpleFlange : AbstractFlange
    {



        protected double db;


        public SimpleFlange(string D, string D1, string D2, string Db, string H, string CountOfHoles) : base(D, D1, D2, H, CountOfHoles)
        {

            paramsList.Add(Db);
            if (CheckParams())
            {
                Build();
            }
            else
                MessageBox.Show("Некорректный ввод!");
        }

        protected override bool CheckParams()
        {
            bool haveNotInvalid = base.CheckParams();

            if (!haveNotInvalid)


                return haveNotInvalid;
            else
            {
                if (IsCorrect(paramsList[paramsList.Count - 1], out db))
                {
                    haveNotInvalid = true;
                }
                else
                {
                    haveNotInvalid = false;
                }
            }
            return haveNotInvalid;
        }

        protected override void Build()
        {
            //System.Runtime.InteropServices.COMException


            base.Build();





        }

    }
}
