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

    public Location(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
        //Hier moeten nog dingen toegevoegd worden
    }
}