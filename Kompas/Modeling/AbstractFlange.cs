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
    internal class AbstractFlange
    {
        //class Plane:Plane3D
        //{
        //    public bool Update()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IKompasAPIObject Parent => throw new NotImplementedException();

        //    public IApplication Application => throw new NotImplementedException();

        //    public KompasAPIObjectTypeEnum Type => throw new NotImplementedException();

        //    public int Reference => throw new NotImplementedException();

        //    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //    public bool Hidden { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //    public bool Valid => throw new NotImplementedException();

        //    public Part7 Part => throw new NotImplementedException();

        //    public global::Kompas6Constants3D.ksObj3dTypeEnum ModelObjectType => throw new NotImplementedException();

        //    public IFeature7 Owner => throw new NotImplementedException();

        //    public MathSurface3D Surface => throw new NotImplementedException();
        //}


        protected Kompas3D kompas3D;


        protected Sketch sketch1,sketch2;
        protected ksSketchDefinition sketch1Definition, sketch2Definition;
        protected Rotated rotated1;
        protected CutExtrusion cutExtrusion1;
        protected MirrorCopyAllDefinition mirrorArray1;
        protected Plane3D planeXOZ;

        protected double d, d1, d2,  h;
        protected int countOfHoles;

        public AbstractFlange(string D, string D1, string D2,  string H, string CountOfHoles)
        {

            //planeXOZ.Name = "ZOX";
            if (IsCorrect(D, out d) && IsCorrect(D1, out d1) && IsCorrect(D2, out d2) && IsCorrect(H, out h) && IsCorrect(CountOfHoles, out countOfHoles))
            {
               
            }
           

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
            //Sketch1();
        }
        protected virtual void Sketch1()
        {
            //sketch1Definition.SetPlane(planeXOZ);
        }

        
    }
}

