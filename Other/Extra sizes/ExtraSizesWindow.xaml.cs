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
namespace Flange.Other.Extra_sizes
{
    /// <summary>
    /// Interaction logic for ExtraSizesWindow.xaml
    /// </summary>

    public partial class ExtraSizesWindow 
    {
        private Binding windowWidthBinding = new Binding("WindowWidth");
        private Binding windowHeightBinding = new Binding("WindowHeight");
        private Binding extraSizesTableColumnWidthBinding = new Binding("MainTabColumnWidth ");

        public static int SelectedFlangeType { get; private set; }
       
        //Binding stackPanelWidthBinding = new Binding("StackPanelWidth");
        public ExtraSizesWindow(int selectedFlangeType)
        {
            InitializeComponent();


            string pathToImage = "";
            switch(selectedFlangeType)
            {
                case Constants.FreeFlange:
                   pathToImage=MainExplorer.SketchesExpl.FreeFlange;
                    break;

                case Constants.FlatFlange:
                    pathToImage = MainExplorer.SketchesExpl.FlatFlange;
                    break;

                case Constants.BlindFlange:
                    pathToImage = MainExplorer.SketchesExpl.BlindFlange;
                    break;

                case Constants.CollarFlange:
                    pathToImage = MainExplorer.SketchesExpl.CollarFlange;
                    break;
            }

            if (!File.Exists(pathToImage))
            {
                MessageBox.Show("Пока не реализовано!");
                this.Close();
                return;
            }


            DataContext = new ExtraViewModel(pathToImage);

            
            SelectedFlangeType = selectedFlangeType;
            

            windowWidthBinding.Source = DataContext;
            windowWidthBinding.Mode = BindingMode.TwoWay;

            windowHeightBinding.Source = DataContext;
            windowHeightBinding.Mode = BindingMode.TwoWay;

            //stackPanelWidthBinding.Source = DataContext;
            //stackPanelWidthBinding.Mode = BindingMode.TwoWay;

            this.SetBinding(WidthProperty,windowWidthBinding);
            this.SetBinding(HeightProperty, windowHeightBinding);


            


            //StackPanelBr.SetBinding(WidthProperty, stackPanelWidthBinding);
        }


        //Максимальная ширина кнопки - 230
        //Минимальная ширина кнопки - 138

    }
}
