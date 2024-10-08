using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PathExplorerLibrary;
namespace Flange.Other
{
    internal class SketchesExplorer : AbstractExplorer
    {
        public SketchesExplorer(PathMaster pathMaster)  : base(pathMaster)
        {
            
        }
        protected override void UniquePaths()
        {
            throw new NotImplementedException();
        }
    }
}
