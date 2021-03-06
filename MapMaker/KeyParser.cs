﻿using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SpaceTaxi_1.MapMaker {
    public static class KeyParser {

        
        /// <summary>
        /// Creates a Dictionary matching a char with a filename.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        
        public static Dictionary<string, string> ParseKey(List<string> keys) {


            Dictionary<string, string> keyMap = new Dictionary<string, string>();
            
            Regex rx = new Regex(@"(?<ASCII>\S)\)\s+(?<name>.+\.png)$");
            Match match;

            foreach (string line in keys)
            {
                match = rx.Match(line);
                if (match.Success) {
                    string path = "Assets\\Images\\" + match.Groups["name"].Value;
                    if (!File.Exists(path))
                    {
                        path = "Assets/Images/" + match.Groups["name"].Value;
                    }
                    keyMap.Add(match.Groups["ASCII"].Value,path);
                }
            }
            return keyMap;
            
        }

    }
}