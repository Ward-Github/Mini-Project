public class Monster
{
    public int ID;
    public string Name;
    public string NamePlural;
    public int MaximumDamage;
    public int RewardExperience;
    public int RewardGold;
    public CountedItemList Loot;
    public int CurrenHitPoints;

    public Monster(int id, string name, string namePlural, int maximumDamage, int rewardExperience, int rewardGold,
        CountedItemList loot, int currenHitPoints)
    {
        ID = id;
        Name = name;
        NamePlural = namePlural;
        MaximumDamage = maximumDamage;
        RewardExperience = rewardExperience;
        RewardGold = rewardGold;
        Loot = loot;
        CurrenHitPoints = currenHitPoints;
    }
}