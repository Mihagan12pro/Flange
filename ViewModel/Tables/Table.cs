using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flange.Other;
using Flange.Model;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Flange.Databases.Classes.Standart.Data_storages;
using Flange.Databases.Classes.Standart;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Flange.ViewModel.Tables
{
    internal abstract class Table : INotifyPropertyChanged
    {
        // public readonly string 

        protected readonly string database;

        protected  ObservableCollection<DataStorage>data;

        protected readonly Controller D,  D1, D2, N;

        public readonly int TableWidth = 500;


        protected int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged();
                SelectedRow();
            }
        }


        protected int countOfColumns;

        public virtual void SelectedRow()
        {
            D.RowValue = Data[SelectedIndex].D;
            D1.RowValue = Data[SelectedIndex].D1;
            D2.RowValue = Data[SelectedIndex].D2;
            N.RowValue = Data[SelectedIndex].N;
        }

        protected double columnWidth;
        public double ColumnWidth
        {
            get { return columnWidth; }
            protected set { columnWidth = value ;OnPropertyChanged(); }
        }
        public ObservableCollection<DataStorage> Data 
        { 
            get
            {
                return data;
            }
            set 
            {
                data = value;
                OnPropertyChanged();
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Table(Controller D,Controller D1,Controller D2,      Controller N)
        {
           
           

            this.D = D;
            this.D1 = D1;
            this.D2 = D2;
            this.N = N;
            database = MainExplorer.DataBaseExpl.DefaultSizesFullName;

            

           // Data = (ObservableCollection<DataStorageSimpleFree>())this.Data;
        }
    }
    class FreeSimpleTable:Table
    {
        protected readonly Controller Db;
        public FreeSimpleTable( Controller  D,Controller D1,Controller D2,  Controller N, Controller Db) : base( D, D1, D2, N)
        {
            this.Db = Db;
            // StandartFreeSimpleFlange standartFreeSimpleFlange = new StandartFreeSimpleFlange();
            Data = new StandartFreeFlange().Data;
            countOfColumns = 5;
            ColumnWidth = (TableWidth / countOfColumns);

         
        }


        public override void SelectedRow()
        {
            base.SelectedRow();


            Db.RowValue = Data[SelectedIndex].Db;
        }
    }
}
