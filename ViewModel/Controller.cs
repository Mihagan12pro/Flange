using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

public class Controller : INotifyPropertyChanged
{
    public Controller(bool _readOnly, int textBoxId)
    {
        


        ReadOnly = _readOnly;
       
        TextBoxId = textBoxId;
    }


    private string textBoxText;
    private bool readOnly;
    private SolidColorBrush background;


    public readonly int TextBoxId;






    public bool ReadOnly
    {
        get
        {
            return readOnly;
        }
            set
        {
            if (readOnly != value)
            {

                if (!value)
                {
                    Background = new SolidColorBrush(Colors.White);
                    OnPropertyChanged(nameof(Background));
                }
                else
                {
                    
                  

                    Background = new SolidColorBrush(Colors.Gainsboro);
                    OnPropertyChanged(nameof(Background));
                }


                readOnly = value;
                OnPropertyChanged();
               
            }
        }
    }

    public SolidColorBrush Background
    {
        get
        {

            return background;
        }
        set
        {
            if  (background != value)
            {
                background = value;
               
            }
        }
       
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



}
