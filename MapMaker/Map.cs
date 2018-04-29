using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DIKUArcade.Entities;

namespace SpaceTaxi_1.MapMaker {
    public class Map : EntityContainer {
        public string Name { get; private set; }
        public List<string> Platforms { get; private set; }
        
        public Map(string metaData) {
            
            Match match = Regex.Match(metaData, @"Name:\s+(?<name>.+)$");

            Name = match.Success ? match.Groups["name"].Value : "";
            Platforms = new List<string>();

            MatchCollection matches = Regex.Matches(metaData, @"Platforms:(?:,*\s+(?<platform>.))*$");

            foreach (Match mtch in matches ) {
                Platforms.Add(mtch.Result("platform"));
            }
            
        }

        public void AddEntityContainer(EntityContainer entityContainter) {
            foreach (Entity entity in entityContainter) {
                AddStationaryEntity(entity.Shape.AsStationaryShape(),entity.Image);
            }
        }
        
        

    }
}