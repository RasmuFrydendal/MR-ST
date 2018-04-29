
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


        public static string RandomParser()
        {
            return "";
        }
        
        public static Map Parser(StreamReader sr) {
            
            string headerName= "";
           
            List<string> keyString = new List<string>();
            string metaDataString = "";
            List<string> mapStrings = new List<string>();
            
            string pattern = @"\s*##(?<header>(";
            foreach (var header in MapParser.parserHeaders) {
                pattern += header+"|";
            }
            pattern = pattern.Remove(pattern.Length - 1);
            pattern += @"))##\s*$";
            
            MapParser.regex = new Regex(pattern);
            
            string line = sr.ReadLine();

            
            while (!sr.EndOfStream) {

                Match match = MapParser.regex.Match(line);
                
                if (match.Success) {
                    headerName = match.Groups["header"].Value;
                } else {
                    switch (headerName) {
                        case "Map":
                            mapStrings.Add(line); 
                            break;
                        case "KeyMap":
                            keyString.Add(line);
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
            sr.Close();
            Map map = new Map(metaDataString);
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
