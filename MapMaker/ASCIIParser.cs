using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace SpaceTaxi_1.MapMaker {
    public class ASCIIParser {

        public static EntityContainer<Entity> MapFromAASCII (String mapString, Dictionary<string,string> keymap, List<string> platforms) {

            EntityContainer returnContainer = new EntityContainer();

            Regex rx = new Regex();
            
            
            foreach (char ASCII in mapString) {
                string key = ASCII.ToString();
                
                if (keymap.ContainsKey(key)) {
                    
                    returnContainer.AddStationaryEntity(new StationaryShape(new Vec2F(2.0f,2.0f),new Vec2F(2.0f,2.0f)), new Image(keymap[key] ));
                    
                }
                
                //Increment row and collum here
            
                
//                while (line != null && MapParser.blankLine.Match(line).Success) {
//                    line = sr.ReadLine();
//                }
//            
//                while(line !=null) {
//                    foreach (var tile in line) {
//                        map.AddStationaryEntity();
//                    }
//                    line = sr.ReadLine();
//                }

                
                
                
            }
            
            return new EntityContainer<Entity>();
        }



    }
}