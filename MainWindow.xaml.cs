using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
//using Flange.Databases.Classes.Standart;
using Flange.Model;
using Flange.Other.WPF_override;
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

            RadioMenuItem kompas3DItem = new RadioMenuItem();
            kompas3DItem.Name = "Kompas3DMenuItem";
            kompas3DItem.Header = "Компас-3D";

            RadioMenuItem nanoCADItem = new RadioMenuItem();
            kompas3DItem.Name = "nanoCadMenuItem";
            kompas3DItem.Header = "nanoCAD";

            ChooseCADMenuItem.InsertChild(kompas3DItem);
            ChooseCADMenuItem.InsertChild(nanoCADItem);

            DataContext = new FlangeViewModel();
            
        }




    }

   
}
