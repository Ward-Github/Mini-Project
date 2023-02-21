using System.Data;

public class Monster
{
    public int ID;
    public string Name;
    public string NamePlural;
    public int MaximumDamage;
    public int RewardExperience;
    public int RewardGold;
    public CountedItemList Loot;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public bool isAlive;

    public Monster(int id, string name, string namePlural, int maximumDamage, int rewardExperience, int rewardGold,
        int currentHitPoints, int maximumHitPoints)
    {
        ID = id;
        Name = name;
        NamePlural = namePlural;
        MaximumDamage = maximumDamage;
        RewardExperience = rewardExperience;
        RewardGold = rewardGold;
        CurrentHitPoints = currentHitPoints;
        MaximumHitPoints = maximumHitPoints;
        Loot = new CountedItemList();
        isAlive = true;
    }

    public bool BossFight(Player player)
    {
        //player naam en health toevoegen
        Console.WriteLine($@"You have come here to defeat the {Name}
{player.Name} Health: {player.CurrentHitPoints}
{Name} Health: {MaximumHitPoints}");
        while (CurrentHitPoints > 0)
        {
            if (player.CurrentHitPoints > 0)
            {
                Random random = new Random();
                int PlayerDamage = random.Next(player.CurrentWeapon.MinimumDamage, player.CurrentWeapon.MaximumDamage);
                int MonsterDamage = random.Next(0, MaximumDamage);
                CurrentHitPoints -= PlayerDamage;
                player.CurrentHitPoints -= MonsterDamage;
                Console.Clear();
                Console.WriteLine($@"Current Weapon: {player.CurrentWeapon.Name}
{Name} hit for {PlayerDamage} HP
You were hit for {MonsterDamage} HP");
                PlayerHealthbar(player);
                EnemyHealthBar();
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You died!");
                return false;
            }
        }
        return true;
    }

    public void PlayerHealthbar(Player player)
    {
        int Health = player.CurrentHitPoints / 10;
        int RemovedHealth = player.MaximumHitPoints/10 - Health;
        Console.Write("Player Healthbar: (");
        for (int i = 0; i < Health; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("x");
        }

        for (int i = 0; i < RemovedHealth; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("x");
        }
        Console.ResetColor();
        Console.Write(")");
        Console.WriteLine();
    }

    public void EnemyHealthBar()
    {
        int Health = CurrentHitPoints;
        int RemovedHealth = MaximumHitPoints - Health;
        Console.Write("Monster Healthbar: (");
        for (int i = 0; i < Health; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("x");
        }
        
        for (int i = 0; i < RemovedHealth; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("x");
        }
        Console.ResetColor();
        Console.Write(")");
        Console.WriteLine();
    }
}