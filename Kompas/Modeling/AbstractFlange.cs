using Kompas6API5;
using Kompas6Constants;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flange.Kompas.Modeling
{
    internal abstract class AbstractFlange
    {
        protected ksDocument3D iDocument3D;
        protected static KompasObject kompas;
       

        protected double d, d1, d2,  h;
        protected int countOfHoles;
        protected List<string> paramsList = new List<string>();

        public AbstractFlange(string D, string D1, string D2,  string H, string CountOfHoles)
        {

            paramsList.Add(D);
            paramsList.Add(D1);
            paramsList.Add(D2);
            paramsList.Add(H);
            paramsList.Add(CountOfHoles);



            //if (IsCorrect(D, out d) && IsCorrect(D1, out d1) && IsCorrect(D2, out d2) && IsCorrect(H, out h) && IsCorrect(CountOfHoles, out countOfHoles))
            //{

            //}

            //if (CheckParams())
            //{
            //    Build();
            //}
            //else
            //{
            //    MessageBox.Show("Введены некорректные значения!");
            //}
        }

        protected virtual bool CheckParams()
        {
            bool haveNotInvalid = true;
            for (int i = 0; i < paramsList.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        haveNotInvalid = IsCorrect(paramsList[i],out d);
                        bool a = haveNotInvalid;
                        break;

                    case 1:
                        haveNotInvalid = IsCorrect(paramsList[i], out d1);
                        break;

                    case 2:
                        haveNotInvalid = IsCorrect(paramsList[i], out d2);
                        break;

                    case 3:
                        haveNotInvalid = IsCorrect(paramsList[i], out h);
                        break;

                    case 4:
                        haveNotInvalid = IsCorrect(paramsList[i], out countOfHoles);
                        break;

                    
                }

                if (haveNotInvalid == false)
                
                    return false;
                
            }


            return true;
        }

        protected virtual bool IsCorrect(string param, out double field)
        {


            if (double.TryParse(param, out field))
            {
                if (field > 0)
                {
                    return true;
                }
            }


            return false;
        }
        protected virtual bool IsCorrect(string param, out int field)
        {


            if (int.TryParse(param, out field))
            {
                if (field > 0)
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual void Build()
        {
            if (kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(t);
            }

            try
            {
                kompas.Visible = true;
                kompas.ActivateControllerAPI();
                iDocument3D = (ksDocument3D)kompas.Document3D();
                iDocument3D.Create(false /*видимый*/, true /*деталь*/);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(t);
                kompas.Visible = true;
                kompas.ActivateControllerAPI();
                iDocument3D = (ksDocument3D)kompas.Document3D();
                iDocument3D.Create(false /*видимый*/, true /*деталь*/);
            }
        }
        protected virtual void Sketch1()
        {
         
        }

        
    }
}

