class Program
{
    public static void Main()
    {
        foreach (Item item in World.Items)
        {
            Console.WriteLine(item.Name);
        }
    }
}