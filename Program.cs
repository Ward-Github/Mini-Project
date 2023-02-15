class Program
{
    public List<Item> Items = World.Items;
    public List<Weapon> Weapons = World.Weapons;
    public List<Monster> Monsters = World.Monsters;
    public List<Quest> Quests = World.Quests;
    public List<Location> Locations = World.Locations;

    public static void Main()
    {
        foreach (Item item in World.Items)
        {
            Console.WriteLine(item.Name);
        }
    }

}