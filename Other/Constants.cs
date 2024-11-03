using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Other
{
    public class ModelType : INotifyPropertyChanged
    {
        private int type;
        public   int Type 
        {
            get
            {
                return type; 
            }
            set
            {
                type = value;

                if (value > AllModels.Count || value < 0)
                    throw eUnknowModelType;

                BuildButtonContent = AllModels[value];

                OnPropertyChanged();
                
            }
        }
        private string buildButtonContent;
        public string BuildButtonContent
        {
            get
            {
                return buildButtonContent;
            }
            private set
            {
                buildButtonContent = value;
                OnPropertyChanged(nameof(BuildButtonContent));
            }
        }

        private Exception eUnknowModelType = new Exception("Unknown model type!");

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public readonly ObservableCollection<string> AllModels  = new ObservableCollection<string> { "Создать 3д модель", "Создать чертеж", "Создать сборку" };
        public ModelType(int _type)
        {
          

            Type = _type;

            //switch(Type)
            //{
            //    case Constants.Model3D:
            //        BuildButtonContent = AllModels[0];
            //        break;

            //    case Constants.Draft2D:
            //        BuildButtonContent = AllModels[1];
            //        break;

            //    case Constants.Assembly:
            //        BuildButtonContent = AllModels[2];
            //        break;

            //    default:
            //        throw eUnknowModelType;
            //}
        }

    }


    public struct FlangeType
    {
        private int id;

        public static readonly List<FlangeType> AllFlangeTypes = new List<FlangeType>() 
        {
            new FlangeType("Свободный фланец", 0),
           
            new FlangeType("Плоский фланец", 1), new FlangeType("Глухой фланец", 2),
            new FlangeType("Воротниковый фланец", 3),new FlangeType("Фланцевая муфта", 4)
        };



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


           // AllFlangeTypes.Add(this);
        }
    }
    internal static class Constants
    {
      
        public static readonly ObservableCollection<string> ModelTypes = new ObservableCollection<string>{ "3д модель","2д чертёж" };


        public const int D = 0;
        public const int D1 = 1;
        public const int D2 = 2;
        public const int Db = 3;
        public const int H = 4;
        public const int N = 5;
        public const int A = 6;
        public const int S = 7;


        public const int Model3D = 0;
        public const int Draft2D = 1;
        public const int Assembly = 2;
        




        public const int FreeFlange = 0, FlatFlange = 1,BlindFlange = 2,CollarFlange = 3;
        //public static readonly Dictionary<int,string> SimpleFlange = { 0,"Фланец"};
        //public const int FreeFlange = 1;
        //public const int FlatFlange = 2;






    }
}
