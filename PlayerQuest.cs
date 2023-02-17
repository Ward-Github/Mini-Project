public class PlayerQuest
{
    public Quest TheQuest;
    public bool IsCompleted;

    public PlayerQuest(Quest theQuest)
    {
        TheQuest = theQuest;
        IsCompleted = false;
    }
}