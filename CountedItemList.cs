public class CountedItemList
{
    public List<CountedItem> TheCountedItemList;

    public CountedItemList()
    {
        TheCountedItemList = new List<CountedItem>();
    }

    public void AddCountedItem(CountedItem newCountedItem)
    {
        bool isFound = false;

        foreach (CountedItem originalCountedItem in TheCountedItemList)
        {
            if (originalCountedItem.TheItem.ID == newCountedItem.TheItem.ID)
            {
                originalCountedItem.Quantity += newCountedItem.Quantity;
                isFound = true;
            }
        }

        if (!isFound)
        {
            TheCountedItemList.Add(newCountedItem);
        }
    }

    public void AddItem(Item item)
    {
        bool isFound = false;

        foreach (CountedItem countedItem in TheCountedItemList)
        {
            if (countedItem.TheItem.ID == item.ID)
            {
                countedItem.Quantity += 1;
                isFound = true;
            }
        }

        if (!isFound)
        {
            TheCountedItemList.Add(new CountedItem(item, 1));
        }

    }
}