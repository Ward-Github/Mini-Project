public class CountedItemList
{ 
    List<CountedItem> TheCountedItemList;

    public CountedItemList()
    {
        TheCountedItemList = new List<CountedItem>();
    }

    public void AddCountedItem(CountedItem countedItem)
    {
        TheCountedItemList.Add(countedItem);
    }

    public void AddItem(Item item)
    {
        bool isFound = false;

        foreach (CountedItem countedItem in TheCountedItemList)
        {
            if (countedItem.TheItem.Name == item.Name)
            {
                countedItem.Quantity += 1;
                isFound = true;
<<<<<<< HEAD
                Console.WriteLine("Done");
=======
>>>>>>> Ward
            }
        }

        if (!isFound)
        {
<<<<<<< HEAD
            TheCountedItemList.Add(new CountedItem(item, 1)); 
            Console.WriteLine("Done");
=======
            TheCountedItemList.Add(new CountedItem(item, 1));
>>>>>>> Ward
        }
        
    }
}