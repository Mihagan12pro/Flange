﻿using System;
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
using System.Data.SqlClient;
using Flange.Other.Abstract_classes_and_interfaces;
internal class Controller : Notify
{

    protected static readonly List<Controller> controllers = new List<Controller>();

    private static readonly Exception eIdDublicate = new Exception("This id is not free!");

    public static int ControllersCount { get; private set; } = 0;

    public static void SetControllers(TheController[]theControllers)
    {
        theControllers = theControllers.OrderBy(controller => controller.Id).ToArray();
        var IDs = (from theContol in theControllers select theContol.Id).Distinct();

        if (IDs.Count() != theControllers.Count())
        {
            throw eIdDublicate;
        }

        ControllersCount++;

        for (int i = 0; i < theControllers.Count(); i++)
        {
            if (theControllers[i].Value == "" || theControllers[i].Value == null)
            {
                controllers[i].RowValue = "";
            }
            else
            {
                controllers[i].RowValue = theControllers[i].Value;  
            }
        }

    }

   

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
            OnPropertyChanged();
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
}
