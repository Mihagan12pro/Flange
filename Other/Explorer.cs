using PathExplorerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Other
{
    internal abstract class Explorer : AbstractExplorer
    {
        protected Explorer(PathMaster filePath) : base(filePath)
        {

        }


    }
}
