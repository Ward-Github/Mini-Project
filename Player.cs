public class Player
{
    public string Name;
    public int CurrentHitPoints = 100;
    public int MaximumHitPoints = 100;
    public int Gold = 0;
    public int ExperiencePoints = 0;
    public int Level = 0;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public QuestList QuestLog;
    public CountedItemList Inventory;
    public List<Weapon> WeaponList;

    public Player(string name)
    {
        Name = name;
        Inventory = new CountedItemList();
        QuestLog = new QuestList();
        WeaponList = new List<Weapon>();
    }

    public void Regeneration(int healing)
    {
        if (CurrentHitPoints + healing >= MaximumHitPoints) CurrentHitPoints = MaximumHitPoints;
        else CurrentHitPoints += healing;
        
        Console.WriteLine($"Health: {CurrentHitPoints}");
    }

    public void DisplayInventory()
    {
        Console.WriteLine("=== Inventory ===");
        foreach (CountedItem countedItem in Inventory.TheCountedItemList)
        {
            Console.WriteLine("* " + countedItem.TheItem.Name);
        }

        Console.WriteLine("================");
    }

    public void DisplayStats()
    {
        Console.WriteLine("=======================");
        Console.WriteLine(Name + " Stats \n");
        Console.WriteLine("Current Hitpoints > " + CurrentHitPoints);
        Console.WriteLine("Gold > " + Gold);
        Console.WriteLine("Level > " + Level);
        Console.WriteLine("=======================");
    }

    public void MoveLocation(Location location)
    {
        if (location != null)
        {
            if (location.ItemRequiredToEnter == null)
            {
                CurrentLocation = location;
            }
            else
            {
                Item requiredItem = location.ItemRequiredToEnter;
                bool hasItem = false;

                foreach (CountedItem countedItem in Inventory.TheCountedItemList)
                {
                    if (countedItem.TheItem == requiredItem)
                    {
                        hasItem = true;
                    }
                }

                if (hasItem)
                {
                    Console.WriteLine("You used your " + requiredItem.Name + " to access this location!");
                    CurrentLocation = location;
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
}
