public class PlayerQuest
{
    public Quest TheQuest;
    public bool IsCompleted;

    public PlayerQuest(Quest theQuest, bool isCompleted)
    {
        this.TheQuest = theQuest;
        this.IsCompleted = isCompleted;
    }
}