using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flange.Model
{
    
    class Parametre : INotifyPropertyChanged
    {
        public readonly int Id;
        private string textBoxValue;
        public Parametre(int Id)
        {
            this.Id = Id;
        }
        public string TextBoxValue
        {
            get
            {
                return textBoxValue;
            }
            set
            {
                if (value != textBoxValue)
                {
                    textBoxValue = value;


                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        

       

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    
    }
}
