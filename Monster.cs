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
        Random random = new Random();
        
        for (int i = 0; i < 3; i++)
        {
            while (CurrentHitPoints > 0)
            {
                if (player.CurrentHitPoints > 0)
                {
                    int playerDamage = random.Next(player.CurrentWeapon.MinimumDamage,
                        player.CurrentWeapon.MaximumDamage + 1);
                    int monsterDamage = random.Next(0, MaximumDamage + 1);

                    player.CurrentHitPoints -= monsterDamage;
                    CurrentHitPoints -= playerDamage;
                    
                    Console.WriteLine("\nPlayer hit for " + monsterDamage);
                    Console.WriteLine("Monster hit for " + playerDamage);
                    
                    Console.WriteLine("Player health > " + player.CurrentHitPoints);
                    Console.WriteLine("Monster health > " + CurrentHitPoints);
                    
                    Thread.Sleep(1000);
                }

                break;
            }

            CurrentHitPoints = MaximumHitPoints;

            if (i == 0) Console.WriteLine($"Defeated 1st {Name}!");
            if (i == 1) Console.WriteLine($"Defeated 2nd {Name}!");
            if (i == 2) Console.WriteLine($"Defeated 3rd {Name}!");
        }

        if (player.CurrentHitPoints > 0) return true;

        return false;
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