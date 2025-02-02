using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Interface
{
    internal interface IFlangeModel
    {
        double _D { get; set; }
        double _H { get; set; }
        ChamferSizesCollection _Chamfers { get;set; }
        string FileExtension { get; set; }
        string OneDrive { get; set; }
        string UserRoot { get; set; }
        string Document {  get; set; }  
    }
}
