using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {   //lijsten toevoegen
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        //items ID geven
        public const int ItemIdBrokenLongsword = 1;
        public const int ItemIdSteelGreatsword = 2;
        public const int ItemIdSceeverFur = 3;
        public const int ItemIdSceeverPaw = 4;
        public const int ItemIdOrcHead = 5;
        public const int ItemIdOrcBlood = 6;
        public const int ItemIdDragosGreataxe = 7;
        public const int ItemIdHealthPotion = 8;
        public const int ItemIdWyvernsScails = 9;
        public const int ItemIdWyvernsBones = 10;
        public const int ItemIdAdventurersPass = 11;

        //monsters ID geven
        public const int MonsterIdSceever = 1;
        public const int MonsterIdOrc = 2;
        public const int MonsterIdDrago = 3;
        public const int MonsterIdWyvern = 4;

        //quests ID geven
        public const int QuestIdClearDemSceevers = 1;
        public const int QuestIdBringDragosGreataxe = 2;

        //locations ID geven
        public const int LocationIdHome = 1;
        public const int LocationIdBoltonTown = 2;
        public const int LocationIdTheRoyalGuardPost = 3;
        public const int LocationIdAlchemistGreysCabin = 4;
        public const int LocationIdAlchemistGreysGarden = 6;
        public const int LocationIdFranklinsFarmhouse = 7;
        public const int LocationIdTheGreatBridge = 8;
        public const int LocationIdSceeversCave = 9;
        public const int LocationIdOrcsDungeon = 10;
        public const int LocationIdDragosLair = 11;
        public const int LocationIdBurningMountains = 12;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateLocations();
            PopulateQuests();
        }

        //alle items toevoegen
        private static void PopulateItems()
        {   //wapens toevoegen
            Items.Add(new Weapon(ItemIdBrokenLongsword, "Broken Longsword", "Broken Longswords", 0, 4));
            Items.Add(new Weapon(ItemIdSteelGreatsword, "Steel Greatsword", "Steel Greatswords", 2, 7));
            Items.Add(new Weapon(ItemIdDragosGreataxe, "Drago's Greataxe", "Drago's Greataxes", 5, 11));
            //items toevoegen
            Items.Add(new Item(ItemIdAdventurersPass, "Adventurers Pass", "Adventurers Passes"));
            Items.Add(new Item(ItemIdSceeverFur, "Sceever Fur", "Sceever Furs"));
            Items.Add(new Item(ItemIdSceeverPaw, "Sceever Paw", "Sceever Paws"));
            Items.Add(new Item(ItemIdOrcBlood, "Orc Blood", "Orc Blood"));
            Items.Add(new Item(ItemIdOrcHead, "Orc Head", "Orc Heads"));
            Items.Add(new Item(ItemIdWyvernsBones, "Wyvern Bone", "Wyvern Bones"));
            Items.Add(new Item(ItemIdWyvernsScails, "Wyvern Scail", "Wyvern Scails"));
            Items.Add(new Item(ItemIdHealthPotion, "Health Potion", "Health Potions"));
        }

        private static void PopulateMonsters()
        {   //monsters details geven
            Monster sceever = new Monster(MonsterIdSceever, "Sceever", 3, 2, 2, 4, 4);
            sceever.LootTable.Add(new LootItem(ItemByID(ItemIdSceeverFur), 75, true));
            sceever.LootTable.Add(new LootItem(ItemByID(ItemIdSceeverPaw), 75, false));

            Monster orc = new Monster(MonsterIdOrc, "Orc", 5, 4, 4, 6, 6);
            orc.LootTable.Add(new LootItem(ItemByID(ItemIdOrcBlood), 75, true));
            orc.LootTable.Add(new LootItem(ItemByID(ItemIdOrcHead), 75, false));

            Monster wyvern = new Monster(MonsterIdWyvern, "Wyvern", 8, 11, 13, 10, 10);
            wyvern.LootTable.Add(new LootItem(ItemByID(ItemIdWyvernsBones), 75, true));
            wyvern.LootTable.Add(new LootItem(ItemByID(ItemIdWyvernsScails), 25, true));

            Monster drago = new Monster(MonsterIdDrago, "Drago", 11, 20, 21, 17, 17);
            drago.LootTable.Add(new LootItem(ItemByID(ItemIdDragosGreataxe), 100, true));

            //monsters in wereld zetten
            Monsters.Add(sceever);
            Monsters.Add(orc);
            Monsters.Add(wyvern);
            Monsters.Add(drago);
        }

        private static void PopulateLocations()
        {   // Locaties toevoegen met quests
            Location home =new Location(LocationIdHome, "HOME", "This is your house.");

            Location bolton_town = new Location(LocationIdBoltonTown, "Bolton Town", "You are in the humble town of Bolton!");

            Location the_royal_guard_post = new Location(LocationIdTheRoyalGuardPost, "The Royal Guard Post", "There are the most fierce looking guards standing there.");

            //locaties linken
            home.LocationToNorth = bolton_town;

            bolton_town.LocationToSouth = home;
            bolton_town.LocationToEast = the_royal_guard_post;

            the_royal_guard_post.LocationToWest = bolton_town;

            Locations.Add(home);
            Locations.Add(bolton_town);
            Locations.Add(the_royal_guard_post);
        }

        private static void PopulateQuests()
        {// quests details geven
            Quest SceeverWeaver = 
                (new Quest(
                    QuestIdClearDemSceevers, 
                    "Sceever Weaver", 
                    "Clear Franklins Farmhouse of his Sceever problem and bring back 6 pieces of Sceever Furs.  He isn't called the 'Sceever Weaver' for nothing!", 10, 13));

            SceeverWeaver.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ItemIdSceeverFur), 6));
            SceeverWeaver.RewardItem = ItemByID(ItemIdHealthPotion);

            //quests toeveoegen
            Quests.Add(SceeverWeaver);
        }


        //Haalt ID's op van onderstaande classes
        public static Item ItemByID(int id)
        {
            foreach(Item item in Items)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach(Monster monster in Monsters)
            {
                if(monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach(Quest quest in Quests)
            {
                if(quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach(Location location in Locations)
            {
                if(location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}
