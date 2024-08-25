using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Flange.Model
{
    internal class FlangeModel : DependencyObject
    {
        private struct FlangeTypeStorage
        {
            public readonly ObservableCollection<string> FlangeTypesCBItems { get;  set; }
        }

        private readonly string SimpleFlangeType;

        


        private bool dVisible ;
        public bool DVisible
        {
            get
            {
                return dVisible;
            }
            set
            {
                dVisible = value;
            }
           
        }

        private string flangeTypeCrl;
        public string FlangeTypeCrl
        {  
            get
            {
                return flangeTypeCrl;
            }
            set
            {
                FlangeTypeCrl = value;

                switch(FlangeTypeCrl)
                {
                    case FlangeTypesCBItems[0]:
                        break;
                }
            }
        }

        public FlangeModel()
        {
            dVisible = false;

           

            

            FlangeTypesCBItems = new ObservableCollection<string>
            {
                "Фланец",
                "Свободный фланец",
                "Плоский фланец"
            };
            flangeTypeCrl = FlangeTypesCBItems[0] ;
        }
        
    }
}
