public class CountedItemList
{ 
    List<CountedItem> TheCountedItemList;

    public CountedItemList(List<CountedItem> theCountedItemList)
    {
        TheCountedItemList = theCountedItemList;
    }

    public void AddCountedItem(CountedItem countedItem)
    {
        TheCountedItemList.Add(countedItem);
    }

    public void AddItem(Item item)
    {
        //Moet nog toegevoegd worden
    }
}