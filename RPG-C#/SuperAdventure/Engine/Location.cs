using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{ 
    public class Location
    {
        public int ID { get; set;}
        public string Name {get; set;}
        public string Description { get; set; }
        public Item ItemYouNeedToEnter { get; set; }
        public Quest QuestAvailableHere { get; set; }
        public Monster MonsterIsHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }

        public Location(int id, string name, string description, Item itemYouNeedToEnter = null, Quest questAvailableHere = null, Monster monsterIsHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemYouNeedToEnter = itemYouNeedToEnter;
            QuestAvailableHere = questAvailableHere;
            MonsterIsHere = monsterIsHere;
        }
    }    
}
