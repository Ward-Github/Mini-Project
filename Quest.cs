public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public Item ItemRequired;
    public Quest QuestAvailableHere;
    public Location LocationToNorth;
    public Location LocationToEast;
    public Location LocationToSouth;
    public Location LocationToWest;
    private int qUEST_ID_COLLECT_SPIDER_SILK;
    private string v1;
    private string v2;
    private int v3;
    private int v4;
    private Item item;
    private object value;

    public Quest(int qUEST_ID_COLLECT_SPIDER_SILK, string v1, string v2, int v3, int v4, Item item, object value)
    {
        this.qUEST_ID_COLLECT_SPIDER_SILK = qUEST_ID_COLLECT_SPIDER_SILK;
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.item = item;
        this.value = value;
    }

    public object QuestCompletionItems { get; internal set; }
}
