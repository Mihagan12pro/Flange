using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flange.Kompas.Modeling
{
    internal class FreeFlange : SimpleFlange
    {
        protected double a, s;

        protected entity iChamfer1;//Фаска
      

        public FreeFlange(string D, string D1, string D2, string Db, string H, string CountOfHoles,string A,string S) : base(D, D1, D2, Db, H, CountOfHoles)
        {

        }

      

        protected override bool CheckParams()
        {
           bool  haveNotInvalid = base.CheckParams();

            if (!haveNotInvalid)


                return haveNotInvalid;
            else
            {
                if (IsCorrect(paramsList[paramsList.Count - 1], out a) && IsCorrect(paramsList[paramsList.Count-2],out s))
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
        }

        protected void Chamfer1()
        {
            iChamfer1 = (entity)iPart.NewEntity((short)Obj3dType.o3d_chamfer);

            ChamferDefinition iChamfer1Definition = (ChamferDefinition)iChamfer1.GetDefinition();

            iChamfer1Definition.tangent = false;
            //iChamfer1Definition.;
        }
    }
}
