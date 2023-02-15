class Program
{
    public List<Item> Items = World.Items;
    public List<Weapon> Weapons = World.Weapons;
    public List<Monster> Monsters = World.Monsters;
    public List<Quest> Quests = World.Quests;
    public List<Location> Locations = World.Locations;

    public static void Main()
    {
        Console.WriteLine("Welcome to our game!");
        string playerName = string.Empty;

        while (playerName == null)
        {
            Console.Write("Name >> ");
            playerName = Console.ReadLine();
        }

        Player player = new Player(playerName);

        while (player.CurrentHitPoints > 0)
        {
            
        }
    }
}