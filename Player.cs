public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public int Gold;
    public int ExperiencePoints;
    public int Level;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public QuestLog QuestList;
    public CounteditemList Inventory;

    public Player(string name, int currentHitPoints,
                  int maximumHitPoints, int gold, int experiencePoints,
                  int level, Weapon currentweapon, Location currentLocation,
                  QuestLog questList, CountedItem inventory)
    {
        Name = name;
        CurrentHitPoints = currentHitPoints;
        MaximumHitPoints = maximumHitPoints;
        Gold = gold;
        ExperiencePoints = experiencePoints;
        Level = level;
        CurrentWeapon = currentweapon;
        CurrentLocation = currentLocation;
        QuestList = questList;
        Inventory = inventory;
    }
}
