public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Item ItemRequiredToEnter;
    public Quest QuestAvilableHere;
    public Location LocationToNorth;
    public Location LocationToEast;
    public Location LocationToSouth;
    public Location LocationToWest;
    private object value1;
    private object value2;
    private object value3;

    public Location(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
        //Hier moeten nog dingen toegevoegd worden
    }

    public Location(int id, string name, string description, object value1, object value2, object value3) : this(id, name, description)
    {
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public Quest QuestAvailableHere { get; internal set; }
    public Monster MonsterLivingHere { get; internal set; }
}