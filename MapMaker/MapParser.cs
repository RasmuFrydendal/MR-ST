
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace SpaceTaxi_1.MapMaker {
    public static class MapParser {

        private static Regex regex;
        
        private static List<string> parserHeaders = new List<string> 
            { "Map",
              "KeyMap",
              "MetaData"
            };
        
        
        public static Map Parser(StreamReader sr) {
            
            string headerName= "";
           
            string keyString = "";
            string metaDataString = "";
            List<string> mapStrings = new List<string>();
            
            string pattern = @"\s*##(?<header>(";
            foreach (var header in MapParser.parserHeaders) {
                pattern += header+"|";
            }
            pattern.Remove(pattern.Length - 1);
            pattern += @")##\s*$";
            
            MapParser.regex = new Regex(pattern);
            
            string line = sr.ReadLine();

            
            while (line != null) {

                Match match = MapParser.regex.Match(line);
                
                if (match.Success) {
                    headerName = match.Result("header") ;
                } else {
                    switch (headerName) {
                        case "Map":
                            mapStrings.Add(line); 
                            break;
                        case "Key":
                            keyString += line;
                            break;
                        case "MetaData":
                            metaDataString += line;
                            break;
                        default:
                            break;
                    }
                }
                line = sr.ReadLine();
            }

            Map map = new Map(MetaParser.Parser(metaDataString));
            Dictionary<string,string> keyMap = KeyParser.ParseKey(keyString);
            map.AddEntityContainer(ASCIIParser.Parser(mapStrings, keyMap , map.Platforms));
            return map;
        }

    }
}


//            
//            
//            while (line != null) {
//                foreach (var regex in MapParser.regexList) {
//                    Match match = regex.Match(line);
//                }
//                line = sr.ReadLine();
//            }
//            
//            while(line !=null) {
//                foreach (var tile in line) {
//                    map.AddStationaryEntity();
//                }
//                line = sr.ReadLine();
//            }
//
//
//            return ASCIIParser.MapFromAASCII(map, null, null);
//
//
//
