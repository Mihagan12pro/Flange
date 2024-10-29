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

namespace Flange.Other.Extra_sizes
{
    /// <summary>
    /// Interaction logic for ExtraSizesWindow.xaml
    /// </summary>
    public partial class ExtraSizesWindow : Window
    {
        private Binding windowWidthBinding = new Binding("WindowWidth");
        private Binding windowHeightBinding = new Binding("WindowHeight");
        //Binding stackPanelWidthBinding = new Binding("StackPanelWidth");
        public ExtraSizesWindow()
        {
            InitializeComponent();


            DataContext = new ExtraViewModel();

            

            

            windowWidthBinding.Source = DataContext;
            windowWidthBinding.Mode = BindingMode.TwoWay;

            windowHeightBinding.Source = DataContext;
            windowHeightBinding.Mode = BindingMode.TwoWay;

            //stackPanelWidthBinding.Source = DataContext;
            //stackPanelWidthBinding.Mode = BindingMode.TwoWay;

            this.SetBinding(WidthProperty,windowWidthBinding);
            this.SetBinding(HeightProperty, windowHeightBinding);
            this.Title = "";
            //StackPanelBr.SetBinding(WidthProperty, stackPanelWidthBinding);
        }
    }
}
