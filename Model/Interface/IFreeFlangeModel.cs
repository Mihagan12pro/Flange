﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Interface
{
    internal interface IFreeFlangeModel : IFlangeModelWithHolesForScrews
    {
        double _Db { get; set; }
    }
}
