using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace SpaceTaxi_1.MapMaker {
    public class ASCIIParser {


        /// <summary>
        /// Parser creates a container of Map entities
        /// </summary>
        /// <param name="mapStrings"></param>
        /// <param name="keymap"></param>
        /// <param name="platforms"></param>
        /// <returns></returns>

        public static EntityContainer Parser (List<string> mapStrings, Dictionary<string,string> keymap, List<string> platforms) {

            EntityContainer returnContainer = new EntityContainer();
            
            List<string> map = ASCIIParser.RemoveEmptyLines(mapStrings);
            
            int row = 1;
            int col = 0;
            
            float tileHeight = 1.0f / map.Count ;

            foreach (string line in map) {
                float tileWidth = 1.0f / line.Length;
                foreach (char key in line) {
                    if (keymap.ContainsKey(key.ToString())) {
                        returnContainer.AddStationaryEntity(
                            new StationaryShape(new Vec2F(col*tileWidth, 1.0f - row*tileHeight), 
                                                new Vec2F(tileWidth, tileHeight)), 
                                                new Image(keymap[key.ToString()] ));   
                    }
                    col++;
                }
                row++;
                col = 0;
            }

            return returnContainer;
        }

        /// <summary>
        /// Removes empty lines at the start and end of the string 
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>

        private static List<string> RemoveEmptyLines(List<string> inputList) {

            Regex emptyLineRegex = new Regex(@"^\s*$");

            //check for null fuldeboi
            
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