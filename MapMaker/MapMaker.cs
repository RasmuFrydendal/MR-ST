using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace SpaceTaxi_1.MapMaker {
    public static class MapMaker {

            //done
        
        public static List<Map> Maps(List<string> names) {


            List<Map> maps = new List<Map>();

            StreamReader mapFile;
            
            foreach (string name in names) {
                
                mapFile = new StreamReader(@"..\..\Levels\" + name +".txt");

                Map map = MapParser.Parser(mapFile);                
                
                maps.Add(map);
                
            }

            return maps;

        }
        
    }
}
