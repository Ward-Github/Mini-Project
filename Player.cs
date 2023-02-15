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

    public Player(string name)
    {
        Name = name;
        Inventory = new CountedItemList();
    }

    public void Regeneration(int healing)
    {
        CurrentHitPoints += healing;
        Console.WriteLine($"Health: {CurrentHitPoints}");
    }
}
