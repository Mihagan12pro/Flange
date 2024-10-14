using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Other
{
    public struct FlangeType
    {
        private int id;
        public int Id
        {
            get => id;
            private set => id = value;
        }


        private string tittle;
        public string Tittle
        {
            get => tittle;
            private set => tittle = value;
        }


        public FlangeType(string _tittle,int _id)
        {
            Tittle = _tittle;
            Id = _id;
        }
    }
    internal static class Constants
    {
        



        public const int D = 0;
        public const int D1 = 1;
        public const int D2 = 2;
        public const int Db = 3;
        public const int H = 4;
        public const int N = 5;
        public const int A = 6;
        public const int S = 7;


        public static readonly FlangeType SimpleFlange = new FlangeType("Фланец",0);
        //public static readonly Dictionary<int,string> SimpleFlange = { 0,"Фланец"};
        //public const int FreeFlange = 1;
        //public const int FlatFlange = 2;


       



    }
}
