using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Flange.Model
{
    class ParametreDouble : Parametre
    {
        public ParametreDouble(int Id, Controller controller) : base(Id, controller)
        {
            // double tryDouble;
        }
        public string TextBoxValue
        {
            get
            {
                return textBoxValue;
            }
            set
            {
                textBoxValue = value;

                //double tryDouble;
                //if (!controller.ReadOnly)
                //{
                //    if (value.Contains("."))

                //        value = value.Replace(".",",");





                //    if (double.TryParse(value, out tryDouble))
                //    {
                //        if (tryDouble > 0)
                //        {
                //            textBoxValue = value;


                //            OnPropertyChanged();
                //        }
                //        else
                //        {
                //            var a = tryDouble;
                //            MessageBox.Show("Данный параметр не может быть меньше нуля!");
                //        }

                //    }
                //    else
                //    {
                //        MessageBox.Show("Данных параметр должен быть числом!");
                //    }
                //}

            }
        }
    }
    class ParametreInt : Parametre
    {

        public ParametreInt(int Id, Controller controller) : base(Id, controller)
        {

        }
        public string TextBoxValue
        {
            get
            {
                return textBoxValue;
            }
            set
            {
               
                int tryInt;
                if (!controller.ReadOnly)
                {
                    if (int.TryParse(value, out tryInt)  )
                    {
                        if (tryInt > 0)
                        {
                            textBoxValue = value;


                            OnPropertyChanged();
                        }
                        else
                        {
                            MessageBox.Show("Данный параметр не может быть меньше нуля!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Данных параметр должен быть целочисленным!");
                    }
                }

            }
        }

    }


    abstract class  Parametre : INotifyPropertyChanged
    {
        public readonly int Id;
        protected string textBoxValue;

        protected Controller controller;
     

        public Parametre(int Id, Controller controller)
        {
            this.Id = Id;
            this.controller = controller;

            protectedParametresList.Add(this);
        }

        public string TextBoxValue;

       
        public event PropertyChangedEventHandler PropertyChanged;
        

       

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected static readonly List<Parametre> protectedParametresList = new List<Parametre>();
        protected static List<Parametre> publicParamentresList = new List<Parametre>();
        
        public static List<Parametre> PublicParametresList
        {
            get 
            {
                return publicParamentresList;
            } 
            set 
            {
                foreach(var par in protectedParametresList)
                {
                    if (!value.Contains(par))
                    {
                        par.TextBoxValue = "";
                    }
                }
            }
        }

    }
}
