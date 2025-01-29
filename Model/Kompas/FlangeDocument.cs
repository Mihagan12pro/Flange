using Kompas6API5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flange.Model.Kompas
{
    internal abstract class FlangeDocument
    {
        protected KompasObject Kompas;
        protected string detailName;

        protected string userRoot;

        protected string OneDrive;

        protected string Documents;

        public virtual void Build()
        {
            ConnectToKompas();
        }

        private void ConnectToKompas()
        {
            try
            {
                Kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                Kompas.Visible = true;
            }
            catch 
            {
                if (Kompas == null)
                {
                    if (Kompas == null)
                    {
                        var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                        Kompas = (KompasObject)Activator.CreateInstance(type);
                    }

                    if (Kompas != null)
                    {
                        Kompas.Visible = true;
                        Kompas.ActivateControllerAPI();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка подключения к программе КОМПАС-3D!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        protected virtual bool ParametresValidation()
        {
            return true;
        }

        public abstract void SaveModel();

        public FlangeDocument(Diameters diameters,Heights heights)
        {
            
        }
    }
}
