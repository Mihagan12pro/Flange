using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flange.ViewModel
{
    internal abstract class CanvasOffset: INotifyPropertyChanged
    {
        public CanvasOffset(double firstSide,double secondSide)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class CanvasOffsetX : CanvasOffset
    {
        private double left;
        public  double Left { get => left;
            private set
            {
                left = value;
                OnPropertyChanged();
            }
        }



        private double right;
        public double Right { get => right;
            private set 
            {
                right = value;
                OnPropertyChanged();
            }
        }

        public CanvasOffsetX(double firstSide, double secondSide):base(firstSide, secondSide) 
        {
            Left = firstSide;
            Right = secondSide;
        }
    }



}
