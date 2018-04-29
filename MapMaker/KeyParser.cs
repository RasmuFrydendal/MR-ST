using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SpaceTaxi_1.MapMaker {
    public static class KeyParser {

        //should be done!
        
        public static Dictionary<string, string> ParseKey(string key) {


            Dictionary<string, string> keyMap = new Dictionary<string, string>();
            
            Regex rx = new Regex(@"(?<ASCII>\S)\)\s+(?<Location>.+.png)");

            Match match = rx.Match(key);
            
            while (match.Success) {             
                keyMap.Add(match.Groups["ASCII"].Value,match.Groups["Location"].Value);
                match.NextMatch();
            }
            
            return keyMap;
            
        }

    }
}