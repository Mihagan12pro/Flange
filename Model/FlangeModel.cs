using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
namespace Flange.Model
{
    internal class FlangeModel : DependencyObject
    {

        private string flangeTypeCrl;
        private readonly string SimpleFlangeType;


        private BitmapImage image;



        public ObservableCollection<string> FlangeTypesCBItems { get; private set; }

        public VisibilityController DVisibleController { get; private set; }
        public VisibilityController D1VisibleController { get; private set; }
        public VisibilityController D2VisibleController { get; private set; }
        public VisibilityController HVisibleController { get; private set; }
        public VisibilityController DbVisibleController { get; private set; }
        public VisibilityController CountOfHolesVisibleConroller { get; private set; }




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

                    FileInfo file;

                    switch (FlangeTypesCBItems.IndexOf(flangeTypeCrl))
                    {
                        case 0:
                            file = new FileInfo(@"..\..\Sketches\SimpleFlange.bmp");
                           
                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;
                    }

                }
            }
        }

       
        public BitmapImage BitmapImage
        {
            get
            {
                return image;
            }
            set
            {
                if (image!=value)
                    image = value;

            }
        }

        
        

        public FlangeModel()
        {
           //DVisibitily = Visibility.Hidden;



            DVisibleController = new VisibilityController(Visibility.Visible);
            D1VisibleController = new VisibilityController(Visibility.Visible);
            D2VisibleController = new VisibilityController(Visibility.Visible);
            HVisibleController = new VisibilityController(Visibility.Visible);
            DbVisibleController = new VisibilityController(Visibility.Visible);
            CountOfHolesVisibleConroller = new VisibilityController(Visibility.Visible);

            FlangeTypesCBItems = new ObservableCollection<string>
            {
                "Фланец",
                "Свободный фланец",
                "Плоский фланец"
            };
            FlangeTypeCrl = FlangeTypesCBItems[0] ;

        
        }
        
    }
}
