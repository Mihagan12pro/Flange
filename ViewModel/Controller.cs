using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

public class Controller : INotifyPropertyChanged
{
    private static readonly List<Controller> controllers = new List<Controller>();
    private readonly Exception eIdDublicate = new Exception("This id is not free!");
    public Controller(bool _readOnly, int textBoxId)
    {
        


        ReadOnly = _readOnly;
       
        TextBoxId = textBoxId;
    }


    private string textBoxText;
    private bool readOnly;
    private SolidColorBrush background;
    
    private string rowValue;
    public string RowValue 
    { 
        get 
        {
            return rowValue;
        } 
        set 
        {
            rowValue = value;
        } 
    }

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


                    RowValue = "";
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
