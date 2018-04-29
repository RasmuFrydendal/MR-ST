using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace SpaceTaxi_1.MapMaker {
    public class ASCIIParser {

        public static EntityContainer<Entity> Parser (List<string> mapStrings, Dictionary<string,string> keymap, List<string> platforms) {

            EntityContainer returnContainer = new EntityContainer();


            List<string> map = ASCIIParser.RemoveEmptyLines(mapStrings);
            
            int row = 0;
            int col = 0;
            
            foreach (string line in map) {
                foreach (char key in line) {
                    if (keymap.ContainsKey(key.ToString())) {
                        returnContainer.AddStationaryEntity(new StationaryShape(new Vec2F(col,row),new Vec2F(col,row)), new Image(keymap[key.ToString()] ));   
                    }
                    row++;
                }

                row = 0;
                col++;



            }
            
            return new EntityContainer<Entity>();
        }


        private static List<string> RemoveEmptyLines(List<string> inputList) {

            Regex emptyLineRegex = new Regex(@"^\s*$");

            int start = 0;
            int end = inputList.Count-1;

            while (emptyLineRegex.Match(inputList[start]).Success) {
                start++;
            }
            while (emptyLineRegex.Match(inputList[end]).Success) {
                end--;
            }

            return inputList.GetRange(start,end);
        }



    }
}