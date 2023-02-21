class Program
{
    public static void Main()
    {
        bool gamePlaying = true;

        string banner = @"
 ▒█████  ▓█████▄▓██   ██▓  ██████   ██████ ▓█████▓██   ██▓
▒██▒  ██▒▒██▀ ██▌▒██  ██▒▒██    ▒ ▒██    ▒ ▓█   ▀ ▒██  ██▒
▒██░  ██▒░██   █▌ ▒██ ██░░ ▓██▄   ░ ▓██▄   ▒███    ▒██ ██░
▒██   ██░░▓█▄   ▌ ░ ▐██▓░  ▒   ██▒  ▒   ██▒▒▓█  ▄  ░ ▐██▓░
░ ████▓▒░░▒████▓  ░ ██▒▓░▒██████▒▒▒██████▒▒░▒████▒ ░ ██▒▓░
░ ▒░▒░▒░  ▒▒▓  ▒   ██▒▒▒ ▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░░░ ▒░ ░  ██▒▒▒ 
  ░ ▒ ▒░  ░ ▒  ▒ ▓██ ░▒░ ░ ░▒  ░ ░░ ░▒  ░ ░ ░ ░  ░▓██ ░▒░ 
░ ░ ░ ▒   ░ ░  ░ ▒ ▒ ░░  ░  ░  ░  ░  ░  ░     ░   ▒ ▒ ░░  
    ░ ░     ░    ░ ░           ░        ░     ░  ░░ ░     
          ░      ░ ░                              ░ ░     
";
        Console.WriteLine(banner);
        string playerName = string.Empty;

        while (playerName == string.Empty)
        {
            Console.Write("Name player >> ");
            playerName = Console.ReadLine();
        }
        Console.Clear();

        Player player = new Player(playerName);
        player.CurrentLocation = World.Locations[0];
        player.CurrentWeapon = World.Weapons[0];

        while (gamePlaying)
        {
            Console.WriteLine("\nWhat would you like to do? ");
            Console.WriteLine("1: See game stats");
            Console.WriteLine("2: Move");
            Console.WriteLine("3: Fight");
            Console.WriteLine("4: Quest list");
            Console.WriteLine("5: Inventory");
            Console.WriteLine("6: Quit\n");
            
            Console.WriteLine("Press number (Keyboard) ");
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine(player.Name + " Stats \n");
                Console.WriteLine("Current Hitpoints > " + player.CurrentHitPoints);
                Console.WriteLine("Gold > " + player.Gold);
                Console.WriteLine("Level > " + player.Level);
                Console.WriteLine("=======================");
            }
            else if (input.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("\nCurrent location: " + player.CurrentLocation.Name);
                Console.WriteLine("Description: " + player.CurrentLocation.Description);

                string map = string.Empty;

                if (player.CurrentLocation.LocationToNorth != null)
                {
                    map += "   N\n";
                    map += "   |\n";
                }

                if (player.CurrentLocation.LocationToEast != null && player.CurrentLocation.LocationToWest!= null)
                {
                    map += "W--|--E\n";
                }
                else if (player.CurrentLocation.LocationToEast != null)
                {
                    map += "   |--E\n";
                }
                else if (player.CurrentLocation.LocationToWest != null)
                {
                    map += "W--|   \n";
                }
            
                if (player.CurrentLocation.LocationToSouth != null)
                {
                    map += "   |\n";
                    map += "   S";
                }
            
                Console.WriteLine(map);
                
                Console.Write("Press on keyboard (N/E/S/W)");
                ConsoleKeyInfo toLocation = Console.ReadKey(true);

                if (toLocation.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    if (player.CurrentLocation.LocationToNorth != null) {
                        if (player.CurrentLocation.LocationToNorth.ItemRequiredToEnter == null)
                        {
                            player.CurrentLocation = player.CurrentLocation.LocationToNorth;
                        }
                        else
                        {
                            Item requiredItem = player.CurrentLocation.LocationToNorth.ItemRequiredToEnter;
                            bool hasItem = false;

                            foreach (CountedItem countedItem in player.Inventory.TheCountedItemList)
                            {
                                if (countedItem.TheItem == requiredItem)
                                {
                                    hasItem = true;
                                }
                            }

                            if (hasItem)
                            {
                                Console.WriteLine("You used your " + requiredItem.Name + " to access this location!");
                                player.CurrentLocation = player.CurrentLocation.LocationToNorth;
                            }
                            else
                            {
                                Console.WriteLine("You don't have the required item to access this location > " + requiredItem.Name);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't go there...");
                    }
                }
                else if (toLocation.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    if (player.CurrentLocation.LocationToEast != null)
                    {
                        if (player.CurrentLocation.LocationToEast.ItemRequiredToEnter == null)
                        {
                            player.CurrentLocation = player.CurrentLocation.LocationToEast;
                        }
                        else
                        {
                            Item requiredItem = player.CurrentLocation.LocationToEast.ItemRequiredToEnter;
                            bool hasItem = false;

                            foreach (CountedItem countedItem in player.Inventory.TheCountedItemList)
                            {
                                if (countedItem.TheItem == requiredItem)
                                {
                                    hasItem = true;
                                }
                            }

                            if (hasItem)
                            {
                                Console.WriteLine("You used your " + requiredItem.Name + " to access this location!");
                                player.CurrentLocation = player.CurrentLocation.LocationToEast;
                            }
                            else
                            {
                                Console.WriteLine("You don't have the required item to access this location > " +
                                                  requiredItem.Name);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't go there...");
                    }
                }
                else if (toLocation.Key == ConsoleKey.W)
                {
                    Console.Clear();
                    if (player.CurrentLocation.LocationToWest != null) 
                    {
                        if (player.CurrentLocation.LocationToWest.ItemRequiredToEnter == null)
                        {
                            player.CurrentLocation = player.CurrentLocation.LocationToWest;
                        }
                        else
                        {
                            Item requiredItem = player.CurrentLocation.LocationToWest.ItemRequiredToEnter;
                            bool hasItem = false;

                            foreach (CountedItem countedItem in player.Inventory.TheCountedItemList)
                            {
                                if (countedItem.TheItem == requiredItem)
                                {
                                    hasItem = true;
                                }
                            }

                            if (hasItem)
                            {
                                Console.WriteLine("You used your " + requiredItem.Name + " to access this location!");
                                player.CurrentLocation = player.CurrentLocation.LocationToWest;
                            }
                            else
                            {
                                Console.WriteLine("You don't have the required item to access this location > " + requiredItem.Name);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't go there...");
                    }
                }
                else if (toLocation.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    if (player.CurrentLocation.LocationToSouth != null) 
                    {
                        if (player.CurrentLocation.LocationToSouth.ItemRequiredToEnter == null)
                        {
                            player.CurrentLocation = player.CurrentLocation.LocationToSouth;
                        }
                        else
                        {
                            Item requiredItem = player.CurrentLocation.LocationToSouth.ItemRequiredToEnter;
                            bool hasItem = false;

                            foreach (CountedItem countedItem in player.Inventory.TheCountedItemList)
                            {
                                if (countedItem.TheItem == requiredItem)
                                {
                                    hasItem = true;
                                }
                            }

                            if (hasItem)
                            {
                                Console.WriteLine("You used your " + requiredItem.Name + " to access this location!");
                                player.CurrentLocation = player.CurrentLocation.LocationToSouth;
                            }
                            else
                            {
                                Console.WriteLine("You don't have the required item to access this location > " + requiredItem.Name);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't go there...");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input...");
                }

                if (player.CurrentLocation.QuestAvailableHere != null)
                {
                    bool alreadyDone = false;
                    
                    foreach (PlayerQuest playerQuest in player.QuestLog.QuestLog)
                    {
                        if (playerQuest.TheQuest.Name == player.CurrentLocation.QuestAvailableHere.Name)
                        {
                            alreadyDone = true;
                        }
                    }
                    
                    if (!alreadyDone) 
                    {
                        Console.Clear();
                        player.QuestLog.QuestLog.Add(new PlayerQuest(player.CurrentLocation.QuestAvailableHere));
                        Console.WriteLine("New quest found!");
                        Console.WriteLine("Quest name > " + player.CurrentLocation.QuestAvailableHere.Name);
                        Console.WriteLine("Quest description > " + player.CurrentLocation.QuestAvailableHere.Description);
                        Console.WriteLine("\nThere will be some rewards for you if you complete it...");
                        Console.WriteLine("Experience points > " + player.CurrentLocation.QuestAvailableHere.RewardExperience);
                        Console.WriteLine("Gold > " + player.CurrentLocation.QuestAvailableHere.RewardGold);
                        if (player.CurrentLocation.QuestAvailableHere.RewardItem != null)
                        {
                            Console.WriteLine("Item > " + player.CurrentLocation.QuestAvailableHere.RewardItem.Name);
                        }

                        if (player.CurrentLocation.QuestAvailableHere.RewardWeapon != null)
                        {
                            Console.WriteLine("Weapon > " + player.CurrentLocation.QuestAvailableHere.RewardWeapon.Name);
                        }
                    }
                }
            }
            else if (input.Key == ConsoleKey.D3)
            {
                Console.Clear();
                if (player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("No monster nearby...");
                }
                else
                {
                    Console.WriteLine("Current equipped weapon > " + player.CurrentWeapon.Name);
                    
                    if (player.WeaponList.Count > 0) 
                    {
                        string availableWeapons = "-- Available weapons --\n";
                        foreach (Weapon weapon in player.WeaponList)
                        {
                            availableWeapons += "( ID: " + weapon.ID + " / Name: " + weapon.Name + " / Min dmg: " + weapon.MinimumDamage + " / Max dmg: " + weapon.MaximumDamage + "\n";
                        }
                        Console.WriteLine(availableWeapons);

                        string weaponSwitch = "";
                        while (weaponSwitch != "S" && weaponSwitch != "C")
                        {
                            Console.Write("Switch weapon or continue (S/C) >> ");
                            var keyInfo = Console.ReadKey();
                            weaponSwitch = keyInfo.Key.ToString().ToUpper();
                            Console.WriteLine();
                        }

                        if (weaponSwitch == "S")
                        {
                            Console.Write("ID weapon >> ");
                            int weaponToEquip = int.Parse(Console.ReadLine());
                            Weapon weapontoEquip = World.WeaponByID(weaponToEquip);
                            player.CurrentWeapon = weapontoEquip;
                            Console.WriteLine("Successfully equipped weapon > " + weapontoEquip.Name);
                        }
                    }

                    bool beatMonster = player.CurrentLocation.MonsterLivingHere.BossFight(player);

                    if (beatMonster)
                    {
                        Console.WriteLine("You have successfully beat > " + player.CurrentLocation.MonsterLivingHere.NamePlural);
                        Console.WriteLine("=== Rewards ===");
                        Console.WriteLine("Gold > " + player.CurrentLocation.MonsterLivingHere.RewardGold);
                        Console.WriteLine("Experience > " + player.CurrentLocation.MonsterLivingHere.RewardExperience);

                        player.Gold += player.CurrentLocation.MonsterLivingHere.RewardGold;
                        player.ExperiencePoints += player.CurrentLocation.MonsterLivingHere.RewardExperience;
                        
                        if (player.QuestLog.QuestLog != null)
                        {
                            foreach (PlayerQuest playerQuest in player.QuestLog.QuestLog)
                            {
                                if (playerQuest.TheQuest.ID == player.CurrentLocation.MonsterLivingHere.ID && playerQuest.IsCompleted == false)
                                {
                                    Console.WriteLine("\nCompleted quest > " + playerQuest.TheQuest.Name + "!");
                                    player.Gold += playerQuest.TheQuest.RewardGold;
                                    player.ExperiencePoints += playerQuest.TheQuest.RewardExperience;
                                    if (playerQuest.TheQuest.RewardItem != null)
                                    {
                                        player.Inventory.AddItem(playerQuest.TheQuest.RewardItem);
                                    }
                                    if (playerQuest.TheQuest.RewardWeapon != null)
                                    {
                                        player.WeaponList.Add(playerQuest.TheQuest.RewardWeapon);
                                    }
                                    playerQuest.IsCompleted = true;
                                }
                            } 
                        }
                    }
                    else
                    {
                        player.CurrentLocation = World.Locations[0];
                        player.CurrentHitPoints = player.MaximumHitPoints;
                        Console.WriteLine("Sadly you died! Luckily you respawned...");
                    }
                }
            }
            else if (input.Key == ConsoleKey.D4)
            {
                Console.Clear();
                Console.WriteLine("=== Quest list ===");
                if (player.QuestLog.QuestLog == null)
                {
                    Console.WriteLine("No quests started...");
                }
                else
                {
                    foreach (PlayerQuest playerQuest in player.QuestLog.QuestLog)
                    {
                        Console.WriteLine("Name > " + playerQuest.TheQuest.Name);
                        Console.WriteLine("Description > " + playerQuest.TheQuest.Description);
                        Console.WriteLine("Experience points > " + playerQuest.TheQuest.RewardExperience);
                        Console.WriteLine("Gold > " + playerQuest.TheQuest.RewardGold);
                        if (playerQuest.TheQuest.RewardItem != null)
                        {
                            Console.WriteLine("Item > " + playerQuest.TheQuest.RewardItem.Name);
                        }

                        if (playerQuest.TheQuest.RewardWeapon != null)
                        { 
                            Console.WriteLine("Weapon > " + playerQuest.TheQuest.RewardWeapon.Name);
                        }
                        Console.WriteLine("Done: " + playerQuest.IsCompleted);
                        Console.WriteLine("==================");
                    }
                }
            }
            else if (input.Key == ConsoleKey.D5)
            {
                Console.Clear();
                Console.WriteLine("=== Inventory ===");
                foreach (CountedItem countedItem in player.Inventory.TheCountedItemList)
                {
                    Console.WriteLine("* " + countedItem.TheItem.Name);
                }
                Console.WriteLine("================");
            }
            else if (input.Key == ConsoleKey.D6)
            {
                gamePlaying = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input...");
            }
            
            if (player.ExperiencePoints >= 10) {
                player.Level += player.ExperiencePoints / 10;
                player.ExperiencePoints = 0;
                player.CurrentHitPoints += 10;
                player.MaximumHitPoints += 10;
                player.CurrentWeapon.MaximumDamage += player.Level;
                Console.WriteLine("\n*************************************");
                Console.WriteLine($"*  You have leveled up to level {player.Level}!  *");
                Console.WriteLine("*************************************");
            }
            
            if (player.QuestLog.QuestLog != null && player.QuestLog.QuestLog.Count == 3)
            {
                bool isDone = true;
                
                foreach (PlayerQuest playerQuest in player.QuestLog.QuestLog)
                {
                    if (playerQuest.IsCompleted == false) isDone = false;
                }

                if (isDone) gamePlaying = false;
            }
        }
        
        Console.WriteLine("Thanks for playing!");
        Console.Write("Press enter to quit...");
        Console.ReadLine();
        Console.WriteLine("Quiting...");
    }
}