using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Flange.Kompas.Modeling
{
    internal abstract class AbstractFlange
    {
        protected  ksDocument3D iDocument3D;
       protected ksDocument2D iDocument2D;

        protected static KompasObject kompas;
        protected ksPart iPart;

        protected  ksEntity planeXOZ;

        protected entity iSketch1, iSketch2;
        protected SketchDefinition iSketch1Definition, iSketch2Definition;

        protected entity iRotation1;
        protected ksBossRotatedDefinition iRotation1Definition;


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

            OpenKompas3D();

            try
            {
                CreateNewDocument();
            }
            catch
            {
                kompas = null;
                OpenKompas3D();
                CreateNewDocument();
            }
            iPart = (part)iDocument3D.GetPart(-1);

            planeXOZ =  (entity)iPart.GetDefaultEntity(2);

            Sketch1();
            Extrusion1();
        }
        private void OpenKompas3D()
        {
            if (kompas == null)
            {
                kompas = new Kompas6API5.Application();
                kompas.Visible = true;
            }
        }
        private void CreateNewDocument()
        {
            iDocument3D = (ksDocument3D)kompas.Document3D();
            iDocument3D.Create(false, true);
        }




        protected  void Sketch1()
        {
            iSketch1  = (entity)iPart.NewEntity(5);
            iSketch1Definition = (SketchDefinition)iSketch1.GetDefinition();

            iSketch1Definition.SetPlane(planeXOZ);

            iSketch1.Create();

            iDocument2D = iSketch1Definition.BeginEdit();

            iDocument2D.ksLineSeg(0,0,0,h,1);
            iDocument2D.ksLineSeg(0,h,d,h,1);
            iDocument2D.ksLineSeg(d,h,d,0,1);
            iDocument2D.ksLineSeg(0,0,d,0,1);

            iDocument2D.ksLineSeg(0, 0, 0, 100, 3);

            iSketch1Definition.EndEdit();
        }

        protected  void Extrusion1()
        {
            iRotation1 = (entity)iPart.NewEntity((short)Obj3dType.o3d_bossRotated);

            iRotation1Definition = (ksBossRotatedDefinition)iRotation1.GetDefinition();


            //ksRotatedParam iRotated1Param = (ksRotatedParam)iRotation1Definition.RotatedParam();


            //iRotated1Param.
            iRotation1Definition.SetThinParam(false, (short)Direction_Type.dtBoth, 1, 1);   // тонкая стенка в два направления
            iRotation1Definition.SetSideParam(true, 360);
            iRotation1Definition .SetSketch(iSketch1);  // эскиз операции вращения

            iRotation1.Create();
        }


    }
}

