// Write a program to keep track of some inventory items as shown below.
// Hint: when creating arrays, as you get or read items into
// your array, then initialize each array spot before its use
// and place a counter or use your own Mylength to keep track
// of your array length as it is used.
using System;
using System.Collections.Generic;

class ItemData
    // for case 2 to work I had to make this a class, not a struct
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
        // use an integer to keep track of the count of items in your inventory (items.Count worked great on its own)
        bool hasQuit = false;
        // create an array of your ItemData struct (i made a list instead)
        var items = new List<ItemData>();
        int IdNumber = 0;
        // use a never ending loop that shows the user what options they can select
        while (!hasQuit)
        {
            Console.WriteLine("Greetings. Choose from the following options:\n1) Add  2) Change  3) Delete  4) List  5) Quit");
            // as long as no one Quits, continue the inventory update
            // in that loop, show what user can select from the list
            // read the user's input and then create what case it falls
            string strx = Console.ReadLine(); // read user's input
            // convert the given string to integer to match our case types shown below
            bool gotIt = int.TryParse(strx, out int optx);
            if (gotIt == false)
            {
                Console.WriteLine("Sorry, your input was invalid. I will bring you to the beginning.");
                continue;
            }
            else
            {

                Console.WriteLine(); // provide an extra blank line on screen
                switch (optx)
                {
                    case 1: // add an item to the list if this option is selected
                        {
                            double pricePerItem; // i initialized these here so they wouldn't be confined inside the try block
                            int quantityOnHand;
                            double ourCostPerItem;
                            Console.WriteLine("Please write a short description of the item.");
                            string description = Console.ReadLine();
                            Console.WriteLine("Please input the cost we charge per item.");
                            try
                            {
                                pricePerItem = double.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("I couldn't understand your input. Going back to main menu.");
                                break;
                            }
                            Console.WriteLine("Please input the quantity.");
                            try
                            {
                                quantityOnHand = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("I couldn't understand your input. Going back to main menu.");
                                break;
                            }
                            Console.WriteLine("Please input the cost we pay per item.");
                            try
                            {
                                ourCostPerItem = double.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("I couldn't understand your input. Going back to main menu.");
                                break;
                            }
                            double valueOfItem = quantityOnHand * ourCostPerItem;
                            var newItem = new ItemData { ItemNumber = IdNumber, Description = description, PricePerItem = pricePerItem, QuantityOnHand = quantityOnHand, OurCostPerItem = ourCostPerItem, ValueOfItem = valueOfItem };
                            items.Add(newItem);
                            IdNumber++; // this ensures each new item will be unique.. the IdNumber will not fill in the blank of a deleted item
                            Console.WriteLine("Your item has been added.");
                            break;
                        }
                    case 2: //change items in the list if this option is selected
                        {
                            Console.Write("Please enter an item ID No:");
                            string input = Console.ReadLine();
                            bool changeGTG = int.TryParse(input, out int changeItemNumber);
                            if (!changeGTG)
                            {
                                Console.WriteLine("I couldn't understand your input. Please try again.");
                                break;
                            }
                            else
                            {
                                bool fFound = false;
                                for (int x = 0; x < items.Count; x++)
                                {
                                    if (items[x].ItemNumber == changeItemNumber)
                                    {
                                        fFound = true;
                                        // code to show what has to happen if the item in the list is found
                                        Console.WriteLine("Which aspect of item number {0} would you like to change?", changeItemNumber);
                                        Console.WriteLine("a)description  b)price  c)quantity  d)cost");
                                        string changeInput = Console.ReadLine();
                                        switch (changeInput)
                                        {
                                            case "a":
                                                {
                                                    Console.WriteLine("Please write a short description of the item.");
                                                    string description = Console.ReadLine();
                                                    items[x].Description = description;
                                                    break;
                                                }

                                            case "b":
                                                {
                                                    Console.WriteLine("Please input the cost we charge per item.");
                                                    bool priceGTG = double.TryParse(Console.ReadLine(), out double pricePerItem);
                                                    if (priceGTG)
                                                    {
                                                        items[x].PricePerItem = pricePerItem;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("I couldn't understand your input. Please try again.");
                                                        break;
                                                    }
                                                }

                                            case "c":
                                                {
                                                    Console.WriteLine("Please input the quantity.");
                                                    bool quantityGTG = int.TryParse(Console.ReadLine(), out int quantityOnHand);
                                                    if (quantityGTG)
                                                    {
                                                        items[x].QuantityOnHand = quantityOnHand;
                                                        items[x].ValueOfItem = items[x].OurCostPerItem * items[x].QuantityOnHand;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("I couldn't understand your input. Please try again.");
                                                        break;
                                                    }
                                                }

                                            case "d":
                                                {
                                                    Console.WriteLine("Please input the cost we pay per item.");
                                                    bool costGTG = double.TryParse(Console.ReadLine(), out double ourCostPerItem);
                                                    if (costGTG)
                                                    {
                                                        items[x].OurCostPerItem = ourCostPerItem;
                                                        items[x].ValueOfItem = items[x].OurCostPerItem * items[x].QuantityOnHand;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("I couldn't understand your input. Please try again.");
                                                        break;
                                                    }
                                                }

                                            default:
                                                {
                                                    Console.Write("Invalid Option, try again\n");
                                                    break;
                                                }
                                        }
                                    }
                                }
                                if (!fFound) // and if not found
                                {
                                    Console.WriteLine("Item {0} not found", changeItemNumber);
                                }
                                break;
                            }
                        }
                    case 3: //delete items in the list if this option is selected
                        {
                            Console.Write("Please enter an item ID No:");
                            int deleteItemNumber;
                            string input = Console.ReadLine();
                            try
                            {
                                deleteItemNumber = int.Parse(input);
                            }
                            catch
                            {
                                Console.WriteLine("I couldn't understand your input. Going back to the beginning.");
                                break;
                            }
                            bool deleted = false;
                            for (int x = 0; x < items.Count; x++)
                            {
                                if (items[x].ItemNumber == deleteItemNumber)
                                {
                                    deleted = true;
                                    // delete the item if you found it
                                    items.Remove(items[x]);
                                    //(Note: your list is now reduced by one item, which items.Count handles)
                                }
                            }
                            if (deleted) // hint the user that you deleted the requested item
                            {
                                Console.WriteLine("Item deleted");
                            }
                            else // if did not find it, hint the user that you did not find it in your list
                            {
                                Console.WriteLine("Item {0} not found\n", deleteItemNumber);
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
                            if (input == "y" || input == "Y")
                            {
                                optx = 0; //as long as it is not 5, the process is not breaking
                                hasQuit = true;
                            }
                            else if (input == "n" || input == "N")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("I couldn't understand your input. I'll bring you to the beginning.");
                            }
                            break;
                        }
                    default:
                        {
                            Console.Write("Invalid Option, try again\n");
                            break;
                        }
                }
            }
        
        }
        Console.WriteLine("Thank you for participating.");
        Console.ReadLine();
    }
}
// Annotations
// with so many opportunities for the user to break the program, exception handling became an enormous undertaking