using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Flange.Other.WPF_override
{
    internal class CustomToolBar: ToolBar
    {
        public static bool GetIsRight(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsRightProperty);
        }
        public static void SetIsRight(DependencyObject obj, bool value)
        {
            obj.SetValue(IsRightProperty, value); 
        }
        public static readonly DependencyProperty IsRightProperty = DependencyProperty.RegisterAttached("IsRight", typeof(bool),typeof(CustomToolBar),new PropertyMetadata(false));


        public CustomToolBar()
        {
            Loaded += delegate
            {
                List<FrameworkElement> items = Items.OfType<FrameworkElement>().ToList();

                FrameworkElement first = items.FirstOrDefault(el => GetIsRight(el));

                if (first == null)
                {
                    return;
                }

                ToolBarPanel tp = Template.FindName("PART_ToolBarPanel",this) as ToolBarPanel;
                Panel dock = VisualTreeHelper.GetParent(tp) as Panel;   
                int idx = dock.Children.IndexOf(tp);
                dock.Children.Remove(tp);

                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto});


                dock.Children.Insert(idx, grid);
                grid.Children.Remove(tp);

                StackPanel rigStack = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                Grid.SetColumn(rigStack,1);
                
                List<FrameworkElement> rigList = items.Skip(items.IndexOf(first)).ToList();
                rigList.ForEach(el => { Items.Remove(el); rigStack.Children.Add(el); });

                grid.Children.Add(rigStack);
            };
        }

    }
}
