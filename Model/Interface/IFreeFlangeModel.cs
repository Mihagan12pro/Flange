using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Interface
{
    internal interface IFreeFlangeModel : IFlangeModel
    {
        double _D1 { get; set; }
        double _D2 { get; set; }
        double _Db { get; set; }
        int _n { get; set; }
    }
}
