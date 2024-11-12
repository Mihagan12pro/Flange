using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using PathExplorerLibrary;
using Flange.Other.Explorers.Master;
namespace Flange.Other
{
    internal static class MainExplorer
    {
        public static readonly SketchesExplorer SketchesExpl;
        public static readonly DataBaseExplorer DataBaseExpl;

        
        static MainExplorer()
        {
            SketchesExpl = new SketchesExplorer(new PathMaster("FreeFlange.png", "Sketches"), new PathMaster("FlatFlange.png", "Sketches"),
                new PathMaster("BlindFlange.png","Sketches"), new PathMaster("CollarFlange.png","Sketches"));
            DataBaseExpl = new DataBaseExplorer( new DataBaseMaster("default_sizes.db", "DBs"), new DataBaseMaster("standart_sizes.db", "DBs"));
        }
    }
}
