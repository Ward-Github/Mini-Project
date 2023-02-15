public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public int RewardExperience;
    public int RewardGold;
    public Item RewardItem;
    public Weapon RewardWeapon;
    public CountedItemList QuestCompletionItems;

    public Quest(int id, string name, string description, int rewardExperience, int rewardGold, Item rewardItem, Weapon rewardWeapon)
    {
        ID = id;
        Name = name;
        Description = description;
        RewardExperience = rewardExperience;
        RewardGold = rewardGold;
        RewardItem = rewardItem;
        RewardWeapon = rewardWeapon;
        QuestCompletionItems = new CountedItemList();
    }
}
