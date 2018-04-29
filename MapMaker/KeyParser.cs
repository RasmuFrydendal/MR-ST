using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SpaceTaxi_1.MapMaker {
    public static class KeyParser {

        //should be done!
        
        public static Dictionary<string, string> ParseKey(List<string> keys) {


            Dictionary<string, string> keyMap = new Dictionary<string, string>();
            
            Regex rx = new Regex(@"(?<ASCII>\S)\)\s+(?<name>.+\.png)$");
            Match match;

            foreach (string line in keys)
            {
                match = rx.Match(line);
                if (match.Success) {             
                    keyMap.Add(match.Groups["ASCII"].Value,"Assets\\Images\\"+ match.Groups["name"].Value);
                    //match.NextMatch();
                }
            }
            return keyMap;
            
        }

    }
}