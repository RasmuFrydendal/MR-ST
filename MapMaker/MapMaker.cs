using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace SpaceTaxi_1.MapMaker {
    public class MapMaker {
        
        public static List<Map> Maps(List<string> names) {


            List<Map> maps = new List<Map>();

            StreamReader mapFile;
            
            foreach (string name in names) {
                
                mapFile = new StreamReader(name+".txt");

                Map map = MapParser.Parser(mapFile);                
                
                maps.Add(map);
                
            }

            return maps;

        }
        
    }
}




// I consideret to make it static, but decided that it would be reasonobal to assume that one
// at some point might wish to create more clusters of maps.
//
//alhtough it might be more reasonable to add to excisting map cluster, maybve we should add options
//for both if it seems reasonable?