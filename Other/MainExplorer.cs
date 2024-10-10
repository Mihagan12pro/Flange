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
     
        static MainExplorer()
        {
          SketchesExpl = new SketchesExplorer(new PathMaster("SimpleFlange.bmp", "Sketches"), new PathMaster("SimpleFlange.bmp", "Sketches"), new PathMaster("SimpleFlange.bmp", "Sketches"));

            //SketchesExpl = new SketchesExplorer(new PathMaster("SimpleFlange.bmp", "Sketches"), new PathMaster("SimpleFlange.bmp", "Sketches"), new PathMaster("SimpleFlange.bmp", "Sketches"));
        }
    }
}
