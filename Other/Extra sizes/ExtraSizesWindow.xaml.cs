using Flange.Other.Extra_sizes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Flange.Other;
using System.IO;
using Flange.Kompas.Modeling;
using Flange.Model.Kompas.Modeling;
using Flange.Model.Kompas;
using Flange.Model.Interface;
namespace Flange.Other.Extra_sizes
{
    /// <summary>
    /// Interaction logic for ExtraSizesWindow.xaml
    /// </summary>

   
    public partial class ExtraSizesWindow
    {
        internal readonly IFlangeModel flangeModel;
        internal ExtraSizesWindow(IFlangeModel flangeModel)
        {
          
            DataContext = new ExtraViewModel(flangeModel);
            InitializeComponent();


           
        }

        private void ExtraWnd_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
        }
    }
}
