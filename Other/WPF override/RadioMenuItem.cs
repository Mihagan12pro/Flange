using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace Flange.Other.WPF_override
{
    internal class RadioMenuItem : MenuItem
    {
        private int id;

        private RadioMenuItemBox father;

        private bool inserted = false;

        public void Insert(RadioMenuItemBox _father,int _id)
        {
            if (!inserted)
            {
                id = _id;
                father = _father;
                inserted = true;
            }
        }

        public RadioMenuItem()
        {
            IsCheckable = true;
        }
    }

    internal class RadioMenuItemBox: MenuItem
    {
        
        public RadioMenuItemBox()
        {
        
        }

        protected override void AddChild(object value)
        {
            RadioMenuItem child = value as RadioMenuItem;

            child.Insert(this,Items.Count);

            base.AddChild(child);
        }
        public void InsertChild(RadioMenuItem menuItem)
        {
            AddChild(menuItem);
        }
    }
   
}
