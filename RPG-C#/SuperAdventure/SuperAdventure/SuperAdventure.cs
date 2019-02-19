using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;

namespace SuperAdventure
{
    public partial class ProPRG : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public ProPRG()
        {
            InitializeComponent();

            Location location = new Location(1, "Home", "This is your house.", null, null, null);
  

            _player = new Player(20, 0, 1, 15, 15);
            MoveTo(World.LocationByID(World.LocationIdHome));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ItemIdBrokenLongsword), 1));
       

            lblHP2.Text = _player.CurrentHP.ToString();
            lblGold2.Text = _player.Gold.ToString();
            lblLVL2.Text = _player.Level.ToString();
            lblXP2.Text = _player.XP.ToString();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btnWeap_Click(object sender, EventArgs e)
        {
            //Pakt de huidige wapen in cboWeapons
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            //Bepaald de aantal damage dat die doet op monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinDamage, currentWeapon.MaxDamage);

            //doet aantal damage op monster
            _currentMonster.CurrentHP -= damageToMonster;

            //Laat zien op scherm dat die damage doet op monster
            rtbMessages.Text += "You hit the " + _currentMonster.Name + " for " + damageToMonster.ToString() + " points." + Environment.NewLine;

            //Kijkt of monster dood is
            if (_currentMonster.CurrentHP <= 0)
            {
                //Monster is dood
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + _currentMonster.Name + Environment.NewLine;

                //Geeft xp aan speler
                _player.XP += _currentMonster.RewardXP;
                rtbMessages.Text += "You receive " + _currentMonster.RewardXP.ToString() + " experience points" + Environment.NewLine;

                //Geeft speler gold 
                _player.Gold += _currentMonster.RewardGold;
                rtbMessages.Text += "You receive " + _currentMonster.RewardGold.ToString() + " gold" + Environment.NewLine;

                //Krijgt willekeurige loot van monster
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                //Voegt items toe in inventory
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }

                //Als er geen random item is gedropt, dan de default item wordt gedropt
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                        }
                    }
                }

                //Voegt dropitem toe in inventory
                foreach (InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                    }
                }

                //Refresh speler information en inventory controls
                lblHP2.Text = _player.CurrentHP.ToString();
                lblGold.Text = _player.Gold.ToString();
                lblXP2.Text = _player.XP.ToString();
                lblLVL2.Text = _player.Level.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                //Voegt blanke messagebox toe
                rtbMessages.Text += Environment.NewLine;

                //Speler op huidige locatie zetten
                MoveTo(_player.CurrentLocation);
            }
            else
            {
                //Monster leeft

                //Bepaald de damage dat monster op speler doet
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaxDamage);

                //Laat message zien van monster
                rtbMessages.Text += "The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                //Haalt HP van speler af
                _player.CurrentHP -= damageToPlayer;

                //Refresh speler UI
                lblHP2.Text = _player.CurrentHP.ToString();

                if (_player.CurrentHP <= 0)
                {
                    //Laat message zien van monster die speler dood maakt
                    rtbMessages.Text += "The " + _currentMonster.Name + " killed you." + Environment.NewLine;

                    //Speler gaat naar Home
                    MoveTo(World.LocationByID(World.LocationIdHome));
                }
            }
        }

        private void btnPot_Click(object sender, EventArgs e)
        {
            //Pakt huidige selectie potion
            HealthPotion potion = (HealthPotion)cboPotions.SelectedItem;

            //Voegt hoeveelheid HP aan speler HP
            _player.CurrentHP = (_player.CurrentHP + potion.AmountHealed);

            //current hp can niet over max hp van speler
            if (_player.CurrentHP > _player.MaxHP)
            {
                _player.CurrentHP = _player.MaxHP;
            }

            //Verwijderd potion van speler inventory
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            //Laat message zien
            rtbMessages.Text += "You drink a " + potion.Name + Environment.NewLine;

            //Monsters zn beurt om aan te vallen

            //Beslist de hoeveelheid damage van monster naar speler hp
            int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaxDamage);

            //Laat message zien
            rtbMessages.Text += "The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

            //Damage gaat van speler hp af
            _player.CurrentHP -= damageToPlayer;

            if (_player.CurrentHP <= 0)
            {
                //Laat message zien
                rtbMessages.Text += "The " + _currentMonster.Name + " killed you." + Environment.NewLine;

                //Verplaatst speler naar "Home"
                MoveTo(World.LocationByID(World.LocationIdHome));
            }

            //Refresh speler data in UI
            lblHP2.Text = _player.CurrentHP.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
        }

        private void MoveTo(Location newLocation)
        {
            //Heeft locatie een item nodig om binnen te komen
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += "You must have a " + newLocation.ItemYouNeedToEnter.Name + " to enter this location." + Environment.NewLine;
                return;
            }

            //Update spelers zn locatie
            _player.CurrentLocation = newLocation;

            //Laat zien/verbergd de beschikbare knoppen
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            //Laat huidige locatie zien van speler
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            //Healt de speler helemaal
            _player.CurrentHP = _player.MaxHP;

            //Update HP in UI
            lblHP2.Text = _player.CurrentHP.ToString();

            //Heeft locatie een quest
            if (newLocation.QuestAvailableHere != null)
            {
                //Kijkt of speler al de quest heeft en de quest klaar is
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                //Kijkt of speler de quest heeft
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + newLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            // Give quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardXP.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            _player.XP += newLocation.QuestAvailableHere.RewardXP;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            // Add the reward item to the player's inventory
                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            // Mark the quest as completed
                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    // Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }

            // Does the location have a monster?
            if (newLocation.MonsterIsHere != null)
            {
                rtbMessages.Text += "You see a " + newLocation.MonsterIsHere.Name + Environment.NewLine;

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterIsHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaxDamage,
                    standardMonster.RewardXP, standardMonster.RewardGold, standardMonster.CurrentHP, standardMonster.MaxHP);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnWeap.Visible = true;
                btnPot.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnWeap.Visible = false;
                btnPot.Visible = false;
            }

            //Refresh spelers inventory list
            UpdateInventoryListInUI();

            //Refresh spelers quest list
            UpdateQuestListInUI();

            //Refresh spelers weapons combobox
            UpdateWeaponListInUI();

            //Refresh spelers potion combobox
            UpdatePotionListInUI();
        }
        
        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;
  
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";
  
            dgvInventory.Rows.Clear();
  
            foreach(InventoryItem inventoryItem in _player.Inventory)
            {
                if(inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }
  
        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;
  
            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";
  
            dgvQuests.Rows.Clear();
  
            foreach(PlayerQuest playerQuest in _player.Quests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
            }
        }
  
        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();
  
            foreach(InventoryItem inventoryItem in _player.Inventory)
            {
                if(inventoryItem.Details is Weapon)
                {
                    if(inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }
  
            if(weapons.Count == 0)
            {
                //Als speler geen weapons heeft, dan btnWeap verbergen
                cboWeapons.Visible = false;
                btnWeap.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
  
                cboWeapons.SelectedIndex = 0;
            }
        }
  
        private void UpdatePotionListInUI()
        {
            List<HealthPotion> healingPotions = new List<HealthPotion>();
  
            foreach(InventoryItem inventoryItem in _player.Inventory)
            {
                if(inventoryItem.Details is HealthPotion)
                {
                    if(inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealthPotion)inventoryItem.Details);
                    }
                }
            }
  
            if(healingPotions.Count == 0)
            {
                //Als speler geen potions heeft, dan btnPot verbergen
                cboPotions.Visible = false;
                btnPot.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";
  
                cboPotions.SelectedIndex = 0;
            }
        }
    }
}
