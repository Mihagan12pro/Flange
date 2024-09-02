using Kompas6API5;
using Kompas6Constants3D;
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

        protected entity iSketch3;
        protected entity iCutExtrusion2;

        public SimpleFlange(string D, string D1, string D2, string Db, string H, string CountOfHoles) : base(D, D1, D2, H, CountOfHoles)
        {

            paramsList.Add(Db);
           
        }

        public override void TryToBuild()
        {
            if (CheckParams())
            
                Build();
            
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
            


            base.Build();


            Sketch3();
            CutExtrusion2();


        }

        protected void Sketch3()
        {

            iSketch3 = (entity)iPart.NewEntity(5);
            SketchDefinition iSketch3Definition = (SketchDefinition)iSketch3.GetDefinition();

            iSketch3Definition.SetPlane(planeOffsetXOY);

            iSketch3.Create();

            iDocument2D = iSketch3Definition.BeginEdit();

            iDocument2D.ksCircle(0, 0,db/2, 1);



            iSketch3Definition.EndEdit();

        }

        protected void CutExtrusion2()
        {
            iCutExtrusion2 = (entity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);

            CutExtrusionDefinition iCutExtrusion2Definition = (CutExtrusionDefinition)iCutExtrusion2.GetDefinition();

            iCutExtrusion2Definition.SetSketch(iSketch3);
            iCutExtrusion2Definition.SetSideParam(false, (short)Direction_Type.dtNormal, h, 1);
            
            iCutExtrusion2.Create();

        }
    }
}
