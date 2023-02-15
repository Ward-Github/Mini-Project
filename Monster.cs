﻿public class Monster
{
    public int ID;
    public string Name;
    public string NamePlural;
    public int MaximumDamage;
    public int RewardExperience;
    public int RewardGold;
    public CountedItemList Loot;
    public int CurrenHitPoints;
    public int MaximumHitPoints;

    public Monster(int id, string name, string namePlural, int maximumDamage, int rewardExperience, int rewardGold,
        int currenHitPoints, int maximumHitPoints)
    {
        ID = id;
        Name = name;
        NamePlural = namePlural;
        MaximumDamage = maximumDamage;
        RewardExperience = rewardExperience;
        RewardGold = rewardGold;
        MaximumHitPoints = maximumDamage;
        CurrenHitPoints = currenHitPoints;
    }
    
}