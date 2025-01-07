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

        protected Lines lines;

        protected entity iChamfer1;//Фаска
      

        public FreeFlange(string D, string D1, string D2,  string H, string CountOfHoles, string Db, string A,string S) : base(D, D1, D2,  H, CountOfHoles, Db)
        {
            paramsList.Add(A);
            paramsList.Add(S);
               
        }

      

        protected override bool CheckParams()
        {
           bool  haveNotInvalid = base.CheckParams();

            if (!haveNotInvalid)


                return haveNotInvalid;
            else
            {
                if (IsCorrect(paramsList[6], out a) && IsCorrect(paramsList[7], out s) && IsCorrect(paramsList[5], out db))
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

            lines = new Lines(s,a);

            Chamfer1();
        }

        protected void Chamfer1()
        {
            iChamfer1 = (entity)iPart.NewEntity((short)Obj3dType.o3d_chamfer);

            ChamferDefinition iChamfer1Definition = (ChamferDefinition)iChamfer1.GetDefinition();

            iChamfer1Definition.tangent = true;
            iChamfer1Definition.SetChamferParam(true,lines.Line1,lines.Line2);

            EntityCollection iEntityCollection = iPart.EntityCollection((short)Obj3dType.o3d_edge);

            EntityCollection iChamferCollection = iChamfer1Definition.array();
           

            iChamferCollection.Clear();

            iEntityCollection.SelectByPoint(db/2, 0, -h);

            iChamferCollection.Add(iEntityCollection.GetByIndex(0));

            iChamfer1.Create();


        }
    }
}
