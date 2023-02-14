public class CountedItemList
{ 
    List<CountedItem> TheCountedItemList;

    public CountedItemList(List<CountedItem> theCountedItemList)
    {
        this.TheCountedItemList = theCountedItemList;
    }

    internal void AddItem(Item item)
    {
        throw new NotImplementedException();
    }
}