using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DIKUArcade.Entities;

namespace SpaceTaxi_1.MapMaker {
    public class Map : EntityContainer {
        public string Name { get; }
        public List<string> Platforms { get; }
        
        public Map(string metaData) {
            Name = Regex.Match(metaData, @"Name:\s+(?<name>.+)$").Result("name");
            Platforms = new List<string>();
            foreach (Match match in Regex.Matches(metaData, @"Platform:(?:,*\s+(?<platform>.))*$")) {
                Platforms.Add(match.Result("platform"));
            }
            
        }

        public void AddEntityContainer(EntityContainer<Entity> entityContainter) {
            foreach (Entity entity in entityContainter) {
                AddStationaryEntity(entity.Shape.AsStationaryShape(),entity.Image);
            }
        }
        
        

    }
}