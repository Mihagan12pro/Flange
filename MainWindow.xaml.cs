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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flange.Model;
namespace Flange
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SketchImage.Height = WindowGrid.Height;

            SizeD1Lbl.MaxWidth = SizeD1Lbl.Width;
            SizeDLbl.MaxWidth = SizeDLbl.Width;
            SizeD2Lbl.MaxWidth = SizeD2Lbl.Width;
            SizeHLbl.MaxWidth = SizeHLbl.Width;



       
            DataContext = new FlangeModel();

          
        }
    }
}
