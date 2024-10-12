using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using PathExplorerLibrary;
namespace Flange.Other
{
    internal static class MainExplorer
    {
        public static readonly SketchesExplorer SketchesExpl;
        public static readonly DataBaseExplorer DataBaseExpl;
     
        static MainExplorer()
        {
            SketchesExpl = new SketchesExplorer(new PathMaster("SimpleFlange.bmp", "Sketches"), new PathMaster("FlatFlange.bmp", "Sketches"), new PathMaster("FreeFlange.bmp", "Sketches"));
            DataBaseExpl = new DataBaseExplorer( new DataBaseLocation("default_sizes.db", "DBs"), new DataBaseLocation("standart_sizes.db", "DBs"));
        }
    }
}
