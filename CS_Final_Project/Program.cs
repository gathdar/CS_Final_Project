// Write a program to keep track of some inventory items as shown below.
// Hint: when creating arrays, as you get or read items into
// your array, then initialize each array spot before its use
// and place a counter or use your own Mylength to keep track
// of your array length as it is used.
using System;
using System.Collections.Generic;

struct ItemData
{
    public int ItemNumber;
    public string Description;
    public double PricePerItem;
    public int QuantityOnHand;
    public double OurCostPerItem;
    public double ValueOfItem;
}
class Program
{
    public static void Main()
    {
        // use an integer to keep track of the count of items in your inventory
        bool hasQuit = false;
        // create an array of your ItemData struct
        var items = new List<ItemData>();
        int countOfItems = items.Count;
        // use a never ending loop that shows the user what options they can select
        while (!hasQuit)
        {
            Console.WriteLine("Greetings. Choose from the following options:\n1) Add  2) Change  3) Delete  4) List  5) Quit");
    // as long as no one Quits, continue the inventory update
    // in that loop, show what user can select from the list
    // read the user's input and then create what case it falls
        string strx = Console.ReadLine(); // read user's input
        int optx = int.Parse(strx); // convert the given string to integer to match our case types shown below
        Console.WriteLine(); // provide an extra blank line on screen
        switch (optx)
        {
            case 1: // add an item to the list if this option is selected
                {
                        Console.WriteLine("Please write a short description of the item.");
                        string description = Console.ReadLine();
                        Console.WriteLine("Please input the cost we pay per item.");
                        double pricePerItem = double.Parse(Console.ReadLine());
                        Console.WriteLine("Please input the quantity.");
                        int quantityOnHand = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please input the cost we charge per item.");
                        double ourCostPerItem = double.Parse(Console.ReadLine());
                        Console.WriteLine("Please indicate the value of the item.");
                        double valueOfItem = double.Parse(Console.ReadLine());
                        var newItem = new ItemData { ItemNumber = items.Count + 1, Description = description, PricePerItem = pricePerItem, QuantityOnHand = quantityOnHand, OurCostPerItem = ourCostPerItem, ValueOfItem = valueOfItem };
                        items.Add(newItem);
                        Console.WriteLine("Your item has been added.");
                        countOfItems++;
                        break;
                }
            case 2: //change items in the list if this option is selected
                {
                    Console.Write("Please enter an item ID No:");
                    string input = Console.ReadLine();
                    int changeItemNumber = int.Parse(input);
                    bool fFound = false;
                    for (int x = 0; x < countOfItems; x++)
                    {
                        if (items[x].ItemNumber == changeItemNumber)
                        {
                            fFound = true;
// code to show what has to happen if the item in the list is found
// reset the count to show a new count for your list
// (Note: your list is now increased by one item)
                        }
        }
        if (!fFound) // and if not found
        {
            Console.WriteLine("Item {0} not found", changeItemNumber);
        }
        break;
    }
case 3: //delete items in the list if this option is selected
{
Console.Write("Please enter an item ID No:");
string input = Console.ReadLine();
    int deleteItemNumber = int.Parse(input);
    bool deleted = false;
for (int x = 0; x<countOfItems; x++)
{
if (items[x].ItemNumber == deleteItemNumber)
{
deleted = true;
// delete the item if you found it
// reset the count to show a new count for your list
//(Note: your list is now reduced by one item)
}
}
if (deleted) // hint the user that you deleted the requested item
{
Console.WriteLine("Item deleted");
}
else // if did not find it, hint the user that you did not find it in your list
{
    Console.WriteLine("Item {0} not found", deleteItemNumber);
}
break;
}
case 4:  //list all items in current database if this option is selected
{
Console.WriteLine("Item#  Description        Price    QOH    Cost     Value  ");
Console.WriteLine("-----  -----------------  -------  -----  -------  -------");
                        // code in this block. Use the above line format as a guide for printing or displaying the items in your list right under it
                        foreach (ItemData item in items)
                        {
                            Console.WriteLine("{0,-5}  {1,-17}  {2, -7}  {3, -5}  {4, -7}  {5, -7}", item.ItemNumber, item.Description, item.PricePerItem.ToString("C"), item.QuantityOnHand, item.OurCostPerItem.ToString("C"), item.ValueOfItem.ToString("C"));
                        }
                        break;
}
case 5: //quit the program if this option is selected
{
Console.Write("Are you sure that you want to quit(y/n)?");
string input = Console.ReadLine();
if (input == "y")
{
optx = 0; //as long as it is not 5, the process is not breaking
                            hasQuit = true;
}
else
                        {
                            break;
                        }
break;
}
default:
{
Console.Write("Invalid Option, try again");
break;
}
}
}
        Console.WriteLine("Thank you for participating.");
        Console.ReadLine();
}
}

// Annotations
