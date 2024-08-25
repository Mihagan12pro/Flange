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
       

        private readonly string SimpleFlangeType;

      

        public ObservableCollection<string> FlangeTypesCBItems { get; private set; }

       
       

        private string flangeTypeCrl;
        private System.Windows.Visibility dVisibility;


        public System.Windows.Visibility DVisibitily
        {
            get
            {
                return dVisibility;
            }
            private set
            {
                if (value != dVisibility)

                    dVisibility = value;
                
            }
        }
        public string FlangeTypeCrl
        {  
            get
            {
                return flangeTypeCrl;
            }
            set
            {

                flangeTypeCrl = value;

               if (flangeTypeCrl!= FlangeTypeCrl)
                {
                    FlangeTypeCrl = flangeTypeCrl;
                }


                switch(FlangeTypesCBItems.IndexOf(FlangeTypeCrl))
                {
                    case 0:

                       

                        break;
                    
                    default:
                        
                        break;
                }
            }
        }

        public FlangeModel()
        {
            DVisibitily = Visibility.Visible;

           

            

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
