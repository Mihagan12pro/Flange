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

        public string FlangeTypeCrl
        {
            get
            {
                return flangeTypeCrl;
            }
            set
            {
                if (value!=flangeTypeCrl)
                {
                    flangeTypeCrl = value;
                }
            }
        }
        
        public VisibilityController DVisibleController { get; private set; }
        public VisibilityController D1VisibleController { get; private set; }



        public FlangeModel()
        {
           //DVisibitily = Visibility.Hidden;



            DVisibleController = new VisibilityController(Visibility.Visible);
            D1VisibleController = new VisibilityController(Visibility.Visible);

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
