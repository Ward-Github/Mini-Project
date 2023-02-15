﻿using System.Data;

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
    }

    public bool BossFight(Player player)
    {
        //player naam en health toevoegen
        Console.WriteLine($@"You have come here to defeat the {Name}
player Health: idk
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
                Console.WriteLine($@"Current Weapon: {player.CurrentWeapon.Name}
{Name} hit for {PlayerDamage} HP
You were hit for {MonsterDamage} HP");
                Thread.Sleep(50);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You died!");
                return false;
            }
        }
        Console.WriteLine("You win!");
        return true;
    }
}