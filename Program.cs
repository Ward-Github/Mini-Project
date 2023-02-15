class Program
{
    public static void Main()
    {
        bool gamePlaying = true;
        
        Console.WriteLine("Welcome to our game!");
        string playerName = string.Empty;

        while (playerName == String.Empty)
        {
            Console.Write("Name player >> ");
            playerName = Console.ReadLine();
        }

        Player player = new Player(playerName);
        player.CurrentLocation = World.Locations[0];

        while (gamePlaying)
        {
            int userInput = 0;

            while (userInput < 1 || userInput > 4)
            {
                Console.WriteLine("\nWhat would you like to do? ");
                Console.WriteLine("1: See game stats");
                Console.WriteLine("2: Move");
                Console.WriteLine("3: Fight");
                Console.WriteLine("4: Quest list");
                Console.WriteLine("5: Quit\n");
                
                Console.Write("Enter number >> ");
                userInput = int.Parse(Console.ReadLine());
            }

            if (userInput == 1)
            {
                Console.WriteLine("=======================");
                Console.WriteLine(player.Name + " Stats \n");
                Console.WriteLine("Current Hitpoints > " + player.CurrentHitPoints);
                Console.WriteLine("Gold > " + player.Gold);
                Console.WriteLine("Level > " + player.Level);
                Console.WriteLine("=======================");
            }
            else if (userInput == 2)
            {
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

                string toLocation = String.Empty;

                while (toLocation != "N" && toLocation != "E" && toLocation != "S" && toLocation != "W")
                {
                    Console.Write("Where to go (N/E/S/W) >> ");
                    toLocation = Console.ReadLine().ToUpper();

                    if (toLocation == "N")
                    {
                        if (player.CurrentLocation.LocationToNorth != null)
                            player.CurrentLocation = player.CurrentLocation.LocationToNorth;
                    }
                    else if (toLocation == "E")
                    {
                        if (player.CurrentLocation.LocationToEast != null)
                            player.CurrentLocation = player.CurrentLocation.LocationToEast;
                    }
                    else if (toLocation == "W")
                    {
                        if (player.CurrentLocation.LocationToWest != null)
                            player.CurrentLocation = player.CurrentLocation.LocationToWest;
                    }
                    else if (toLocation == "S")
                    {
                        if (player.CurrentLocation.LocationToSouth != null)
                            player.CurrentLocation = player.CurrentLocation.LocationToSouth;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input...");
                    }

                    if (player.CurrentLocation.QuestAvailableHere != null)
                    {
                        player.QuestLog.QuestLog.Add(new PlayerQuest(player.CurrentLocation.QuestAvailableHere));
                        Console.WriteLine("New quest found!");
                        Console.WriteLine("Quest name > " + player.CurrentLocation.QuestAvailableHere.Name);
                        Console.WriteLine("Quest description > " + player.CurrentLocation.QuestAvailableHere.Description);
                        Console.WriteLine("\nThere will be some rewards for you if you complete it...");
                        Console.WriteLine("Experience points > " + player.CurrentLocation.QuestAvailableHere.RewardExperience);
                        Console.WriteLine("Gold > " + player.CurrentLocation.QuestAvailableHere.RewardGold);
                        Console.WriteLine("Item > " + player.CurrentLocation.QuestAvailableHere.RewardItem.Name);
                        Console.WriteLine("Weapon > " + player.CurrentLocation.QuestAvailableHere.RewardWeapon.Name);
                    }
                }
                
            }
            else if (userInput == 3)
            {
                // Quest != Monster, Dit aanpassen.
                
                if (player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("No monster nearby...");
                }
                else
                {
                    Console.WriteLine("Current equipped weapon > " + player.CurrentWeapon);
                        
                    string availableWeapons = "-- Available weapons --";
                    foreach (Weapon weapon in World.Weapons)
                    {
                        availableWeapons += "( ID: " + weapon.ID + " / Name: " + weapon.Name + " / Min dmg: " + weapon.MinimumDamage + " / Max dmg: " + weapon.MaximumDamage + "\n";
                    }
                    Console.WriteLine(availableWeapons);

                    string weaponSwitch = string.Empty;
                    while (weaponSwitch != "S" && weaponSwitch != "C")
                    {
                        Console.Write("Switch weapon or continue (S/C) >> ");
                        weaponSwitch = Console.ReadLine();
                    }

                    if (weaponSwitch == "S")
                    {
                        Console.Write("ID weapon >> ");
                        int weaponToEquip = int.Parse(Console.ReadLine());
                        player.CurrentWeapon = World.WeaponByID(weaponToEquip);
                    }
                }
            }
            else if (userInput == 4)
            {
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
                        Console.WriteLine("Item > " + playerQuest.TheQuest.RewardItem.Name);
                        Console.WriteLine("Weapon > " + playerQuest.TheQuest.RewardWeapon.Name);
                        Console.WriteLine("==================");
                    }
                }
            }
            else if (userInput == 5)
            {
                gamePlaying = false;
            }
            else
            {
                Console.WriteLine("Invalid input...");
            }
        }
        
        Console.WriteLine("Thanks for playing!");
        Console.WriteLine("Press enter to quit...");
        Console.ReadLine();
        Console.WriteLine("Quiting...");
    }
}