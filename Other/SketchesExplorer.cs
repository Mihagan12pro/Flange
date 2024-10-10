using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flange.Kompas.Modeling;
using PathExplorerLibrary;
namespace Flange.Other
{
    class SketchesExplorer :Explorer
    {
       
        private readonly PathMaster simpleFlangePath;
        private readonly PathMaster flatFlangePath;
        private readonly PathMaster freeFlangePath;

        public readonly string SimpleFlange;
        public readonly string FlatFlange;
        public readonly string FreeFlange;
        public SketchesExplorer(PathMaster simpleFlangePath,PathMaster flatFlangePath,PathMaster freeFlangePath)  : base(simpleFlangePath)
        {
            this.simpleFlangePath = simpleFlangePath;
            this.flatFlangePath = flatFlangePath;
            this.freeFlangePath = freeFlangePath;





            pathMasters.Add(this.simpleFlangePath);
            pathMasters.Add(this.freeFlangePath);
            pathMasters.Add(this.flatFlangePath);

            SimpleFlange = this.simpleFlangePath.FilePath;
            FlatFlange = this.flatFlangePath.FilePath;
            FreeFlange = this.freeFlangePath.FilePath;

            UniquePaths();
        }

       
    }
}
