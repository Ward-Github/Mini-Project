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
    private int mONSTER_ID_RAT;
    private string v1;
    private string v2;
    private int v3;
    private int v4;
    private int v5;
    private int v6;
    private int v7;

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

    public Monster(int mONSTER_ID_RAT, string v1, string v2, int v3, int v4, int v5, int v6, int v7)
    {
        this.mONSTER_ID_RAT = mONSTER_ID_RAT;
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.v5 = v5;
        this.v6 = v6;
        this.v7 = v7;
    }
}