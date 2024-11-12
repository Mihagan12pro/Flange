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
       
        private readonly PathMaster freeFlangePath;
        private readonly PathMaster flatFlangePath;
        private readonly PathMaster blindFlangePath;
        private readonly PathMaster collarFlangePath;
        private readonly PathMaster couplingFlangePath;


        public readonly string FlatFlange;
        public readonly string FreeFlange;
        public readonly string CollarFlange;//Воротниковый фланец
        public readonly string CouplingFlange;//Фланцевая муфта
        public readonly string BlindFlange;

        public SketchesExplorer(PathMaster freeFlangePath,PathMaster flatFlangePath,
            PathMaster blindFlangePath,PathMaster collarFlangePath)  : base(freeFlangePath)
        {
            this.freeFlangePath = freeFlangePath;
            this.flatFlangePath = flatFlangePath;
            this.blindFlangePath = blindFlangePath;
            this.collarFlangePath = collarFlangePath;
            





            pathMasters.Add(this.freeFlangePath);
     
            pathMasters.Add(this.flatFlangePath);

            FreeFlange = this.freeFlangePath.FilePath;
            FlatFlange = this.flatFlangePath.FilePath;
            BlindFlange = this.blindFlangePath.FilePath;
            CollarFlange = this.collarFlangePath.FilePath;
           

            UniquePaths();
        }

       
    }
}
