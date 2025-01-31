using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Flange.Other.Abstract_classes_and_interfaces;
namespace Flange.Other
{
    
    internal static class Constants
    {
      
        public static readonly ObservableCollection<string> ModelTypes = new ObservableCollection<string>{ "3д модель","2д чертёж" };


        //public const int D = 0;
        //public const int D1 = 1;
        //public const int D2 = 2;
        //public const int Db = 3;
        //public const int H = 4;
        //public const int N = 5;
        //public const int A = 6;
        //public const int S = 7;


        public const int Model3D = 0;
        public const int Draft2D = 1;
        public const int Assembly = 2;

        public const bool Forward = true;
        public const bool Backward = false;


        public const int TOP = 0;
        public const int BOTTOM = 1;
        




        public const int FreeFlange = 0, FlatFlange = 1,BlindFlange = 2,CollarFlange = 3;
        //public static readonly Dictionary<int,string> SimpleFlange = { 0,"Фланец"};
        //public const int FreeFlange = 1;
        //public const int FlatFlange = 2;






    }
}
