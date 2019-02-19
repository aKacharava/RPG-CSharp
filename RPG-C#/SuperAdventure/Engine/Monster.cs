using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : LivingCreature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int RewardGold { get; set; }
        public int RewardXP { get; set; }
        public List<LootItem> LootTable { get; set;}

        public Monster(int id, string name, int maxDamage, int rewardGold, int rewardXP, int currentHP, int maxHP) : base (currentHP, maxHP)
        {
            ID = id;
            Name = name;
            MaxDamage = maxDamage;
            RewardGold =rewardGold;
            RewardXP = rewardXP;
            LootTable = new List<LootItem>();
        }
         
    }
}
