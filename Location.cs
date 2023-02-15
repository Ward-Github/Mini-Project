public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Item ItemRequiredToEnter;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
    public Location? LocationToNorth = null;
    public Location? LocationToEast = null;
    public Location? LocationToSouth = null;
    public Location? LocationToWest = null;

    public Location(int id, string name, string description, Item itemRequiredToEnter, Quest questAvailableHere, Monster monsterLivingHere)
    {
        ID = id;
        Name = name;
        Description = description;
        ItemRequiredToEnter = itemRequiredToEnter;
        QuestAvailableHere = questAvailableHere;
        MonsterLivingHere = monsterLivingHere;
    }
    
}