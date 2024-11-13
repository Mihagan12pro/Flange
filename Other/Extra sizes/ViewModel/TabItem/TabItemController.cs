using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Flange.Other.Abstract_classes_and_interfaces;
namespace Flange.Other.Extra_sizes.ViewModel.TabItems
{
    class AbstractTabItem : Notify
    {

        public TabItem TabItem { get; protected set; }

        public AbstractTabItem(string header,string content)
        {

            TabItem = new TabItem()
            {
                Header = header,
                Content = content
            };
        }
    }

    internal class TabItemClassic : AbstractTabItem
    {
        public TabItemClassic(string header, string content) : base(header, content)
        {

        }
    }

}
