using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Interface
{
    interface IFlangeModelWithHolesForScrews : IFlangeModel
    {
        int _n { get; set; }
        double _D1 { get; set; }
        double _D2 { get; set; }
    }
}
