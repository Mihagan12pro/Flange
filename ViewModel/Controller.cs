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
using System.Linq;
using Flange.Other;
using Flange.Model;
public class Controller : INotifyPropertyChanged
{
    protected static readonly List<Controller> controllers = new List<Controller>();
    private readonly Exception eIdDublicate = new Exception("This id is not free!");
    public void GetControllers(List<TheController>theControllers)
    {
        theControllers = theControllers.OrderBy(controller => controller.Id).ToList();
        var IDs = (from theContol in theControllers select theContol.Id).Distinct();

        if (IDs.Count() != theControllers.Count)
        {
            throw eIdDublicate;
        }

        for (int i = 0; i < theControllers.Count; i++)
        {
        }

    }

    
    //public static List<Controller>Controllers
    //{
    //    get
    //    {
    //        return controllers;
    //    }
    //}





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




    private readonly int id;
    public  int ID
    {
        get
        {
            return id;
        }
    }





    private bool readOnly;
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


    private SolidColorBrush background;

    public SolidColorBrush Background
    {
        get
        {

            return background;
        }
        set
        {
            if (background != value)
            {
                background = value;

            }
        }

    }
 
    public Controller(bool _readOnly, int textBoxId)
    {
        

        ReadOnly = _readOnly;
       
        id = textBoxId;


        if ((from controller in controllers where controller.ID == ID select controller).Count() > 0)
            throw eIdDublicate;


        controllers.Add(this);
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



}
