using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flange.Kompas.Modeling;
using PathExplorerLibrary;
namespace Flange.Other
{
    class SketchesExplorer : AbstractExplorer
    {
        public readonly PathMaster SimpleFlangePath;
        public readonly PathMaster FlatFlangePath;
        public readonly PathMaster FreeFlangePath;
        public SketchesExplorer(PathMaster simpleFlangePath,PathMaster flatFlangePath,PathMaster freeFlangePath)  : base(simpleFlangePath)
        {
            SimpleFlangePath = simpleFlangePath;
            FlatFlangePath = flatFlangePath;
            FreeFlangePath = freeFlangePath;

            pathMasters.Add(SimpleFlangePath);
            pathMasters.Add(FreeFlangePath);
            pathMasters.Add(FlatFlangePath);

        }
        protected override void UniquePaths()
        {
            var collection = (from master in pathMasters select master.FilePath).Distinct();

            if (collection.Count() != pathMasters.Count())
                throw eDublicateObjects;
        }
    }
}
