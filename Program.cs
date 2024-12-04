using System.Formats.Tar;
using System.IO;
namespace SimpleDataBase
{
    internal class Program
    {
        //3. Build the program structure "list". this is defined as global varibale due to some improvement of the current task
        public static List <List<string>> items = new List <List<string>>();
        //3. end of no 3
        public static Boolean exist = false;
        public static Boolean check = true;
        static void Main(string[] args)
        {
            //properties\values
  
            int numChoice = 0;
            string item_index;
            string name;
            int index_of;
            ItemCategories categ = 0;
            Boolean exit = true;
            int num;
            string quant;
            Boolean loops = true;
            
            


            //start of the program line
                LoadInventory();
                int row = items.Count();
                Console.WriteLine("\nWelcome to your simple inventory!");
                Console.ReadKey();
                Console.WriteLine("\nAdd items to the inventory (or type 'exit' to stop):\n");
                Console.WriteLine("NOTE: You can't type the same item twice and make sure the choices has a value):\n");
   
            while (exit)
            {
                Console.WriteLine($"\nTOTAL NUMBER OF ITEMS IN YOUR INVENTORY: {row}");
                Console.WriteLine("-------------------------------------------------------");
                items.Add(new List<string>());
                check = true;
                loops = true;
                while (true)
                    {
                        
                        while (true)
                        {
                            Boolean check = false;
                            
                            while(true)
                            {
                            Console.Write("\nEnter item name: ");
                            name = Console.ReadLine();
                            //3. tryparse to handle non-integer value
                            if (int.TryParse(name, out int nums))
                            {
                                Console.WriteLine("\nYou cant type a number as a name");
                                Console.ReadKey();
                            }
                            else
                            {
                                break;
                            }
                            }
                            //3. allow user to exit
                            if (name.ToUpper() == "EXIT")
                            {
                                Console.WriteLine("You are exiting the program.");
                                return;
                            }
                            if (name == "")
                            {
                                Console.WriteLine("\nName has no value!");
                                check = true;
                                Console.ReadKey();
                            }
                            foreach (var item in items)
                            {
                                foreach (string values in item)
                                {
                                    if (values == name)
                                    {
                                        Console.WriteLine("\nThis name already exist");
                                        Console.ReadKey();
                                        check = true;
                                    }
                                }
                            }
                            if (!check)
                            {
                                break;
                            }
                        }
                        items[row].Add(name);
                        Console.Write("\nEnter item quantity: ");
                        quant = Console.ReadLine();
                        if (quant.ToUpper() == "EXIT")
                        {
                            Console.WriteLine("\nYou are exiting the program.");
                            return;
                        }
                        items[row].Add(quant);
                        if (int.TryParse(quant, out num))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("this is not an integer value");
                            Console.ReadKey();
                            items[row].Remove(quant);
                           
                        }
                    }

                    Console.WriteLine($"\nYour categories" +
                        $"\n ({(int)ItemCategories.Electronics}) : Electronics" +
                        $"\n ({(int)ItemCategories.Clothing}) : Clothing" +
                        $"\n ({(int)ItemCategories.Groceries}) : Groceries" +
                        $"\n ({(int)ItemCategories.Stationary}) : Stationary" +
                        $"\n ({(int)ItemCategories.Miscellaneous}) : Miscellaneous");

                    while(true)
                    {
                        Console.Write("\nChoose category: ");
                        item_index = Console.ReadLine();
                        if (item_index.ToUpper() == "EXIT")
                        {
                            Console.WriteLine("\nYou are exiting the program.");
                            return;
                        }
                        if (int.TryParse(item_index, out index_of))
                        {
                            if (index_of < 5 && index_of >= 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\ncategory number out of bounds");
                                Console.ReadKey();
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nthis is not an integer value");
                            Console.ReadKey();
                        }
                    }
      
                    switch(index_of)
                    {
                        case 0:
                            categ = ItemCategories.Electronics;
                            break;
                        case 1:
                            categ = ItemCategories.Clothing;
                            break;
                        case 2:
                            categ = ItemCategories.Groceries;
                            break;
                        case 3:
                            categ = ItemCategories.Stationary;
                            break;
                        case 4:
                            categ = ItemCategories.Miscellaneous;
                            break;
                    }
                    string category_container = categ.ToString();
                    items[row].Add(category_container);

                    //Taking the values on struct and display on the console while saving the list to the txt file muah
                    InventoryItems itemDisplay = new InventoryItems(name, num, categ);
                    Console.WriteLine(itemDisplay);
                    Console.ReadKey();
                    SaveInventory();
                    Console.WriteLine("\nItem has been saved!");
                    Console.ReadKey();

                    // Searching or displaying values
                    Console.WriteLine("\nDo you wish to display all items or search specific item in the inventory?" +
                                          "\n(NOTE: You can always type exit if you want to stop the program)\n"+
                                          "\n (1) Display, Search, or Delete" +
                                          "\n (2) Proceed on adding items on the inventory"); 
                
                    while(true)
                    {
                        Console.Write("\nYour Choice: ");
                        string choice = Console.ReadLine();
                        if (choice.ToUpper() == "EXIT")
                        {
                            Console.WriteLine("\nYou are exiting the program.");
                            return;
                        }
                        if (int.TryParse(choice, out numChoice))
                        {
                                if (numChoice < 3 && numChoice > 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nChoice out of bounds");
                                    Console.ReadKey();
                                }
                        }
                    }
                        if(numChoice == 1)
                        {
                            while(loops)
                            {
                                check = true;
                                exist = false;
                                Console.WriteLine("\n|DISPLAY OR SEARCH|");
                                Console.WriteLine("\n (1) Display All" +
                                              "\n (2) Display Electronics" +
                                              "\n (3) Display Clothings" +
                                              "\n (4) Display Groceries" +
                                              "\n (5) Display Stationary" +
                                              "\n (6) Display Miscellaneous" +
                                              "\n (7) Search Item" +
                                              "\n (8) Remove All" +
                                              "\n (9) Add Item");
                                Console.Write("\nYour choice: ");
                                string display_choice = Console.ReadLine();
                                if (display_choice.ToUpper() == "EXIT")
                                {
                                    Console.WriteLine("\nYou are exiting the program.");
                                    return;
                                }
                                if (int.TryParse(display_choice, out int display_choicen))
                                {
                                    if(display_choicen > 0 && display_choicen < 10)
                                    {
                                        switch(display_choicen)
                                        {
                                            case 1:
                                                Display_all();
                                                Console.ReadKey();
                                            break;
                                            case 2:
                                                    Display_Specific("Electronics");
                                                if (check)
                                                {
                                                    Console.WriteLine("\nThis Category is empty");
                                                
                                                }
                                                Console.ReadKey();
                                            break;
                                            case 3:
                                                    Display_Specific("Clothing");
                                                
                                                if (check)
                                                {
                                                    Console.WriteLine("This Category is empty");
                                                }
                                                Console.ReadKey();
                                            break;
                                            case 4:
                                                Display_Specific("Groceries");
                                                if (check)
                                                {
                                                    Console.WriteLine("This Category is empty");
                                               
                                                }
                                                Console.ReadKey();
                                            break;
                                            case 5:
                                                Display_Specific("Stationary");
                                                if (check)
                                                {
                                                    Console.WriteLine("This Category is empty");
                                              
                                                }
                                                Console.ReadKey();
                                            break;
                                            case 6:
                                                Display_Specific("Miscellaneous");
                                                if (check)
                                                {
                                                    Console.WriteLine("This Category is empty");
                                                }
                                                Console.ReadKey();
                                            break;
                                            case 7:
                                                Console.Write("\nSearch Item: ");
                                                string search = Console.ReadLine();
                                                if (search.ToUpper() == "EXIT")
                                                {
                                                    Console.WriteLine("You are exiting the program.");
                                                    return;
                                                }
                                                searchItem(search);
                                                Console.ReadKey();
                                            break;
                                            case 8:
                                                Console.WriteLine("\nAre you sure you want to delete all datas?" +
                                                    "\n(1) YES " +
                                                    "\n(2) NO");
                                                Console.Write("Your Choice: ");
                                                string choice = Console.ReadLine();
                                                if (choice.ToUpper() == "EXIT")
                                                {
                                                    Console.WriteLine("\nYou are exiting the program.");
                                                    return;
                                                }
                                                if (choice == "1")
                                                {
                                                     if (File.Exists("inventory.txt"))
                                                     {
                                                        File.WriteAllText("inventory.txt", String.Empty);
                                                        LoadInventory();
                                                        Console.WriteLine("\n Succesfull deletion on the txt file. please refresh the program");
                                                        Console.ReadKey();
                                                     }
                                                    else
                                                    {
                                                        Console.WriteLine("\nThere is no file");
                                                        Console.ReadKey();
                                                    }
                                                }
                                                if (choice == "2")
                                                {
                                                    break;
                                                }
                                            break;
                                            case 9:
                                            loops = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThis choice is out of boundaries");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nThis is not a number");
                                }
                            }
                        
                        }
                        if (numChoice == 2)
                        {
                        
                        }
                    row++;      
            }
        }

        //4. The load invenoory - This load and store the values on list in the inventory.txt
        public static void LoadInventory()
        {
            // I create a temporary array to store the current content of the list items
            if (File.Exists("inventory.txt"))
            {
                //5. Try Catch under LoadInventory
                try
                {
                    string[] content = File.ReadAllLines("inventory.txt");

                    int x = items.Count();

                    foreach (string contents in content)
                    {
                        string[] values = contents.Split(',');
                        items.Add(new List<string>());
                        foreach (string val in values)
                        {
                            items[x].Add(val);
                        }
                        x++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occur " + e);
                }
            }
            else
            {
                Console.WriteLine("No previous Inventory was found");
            }
        }

        // 4. Save Inventory - this function reads all the values --- name, quantity, category --- on the list items,
        // Used Count List method to capture the row of multidimensional List and
        // store it on the txt file using StreamWriter
        public static void SaveInventory()
        {
            StreamWriter write = new StreamWriter("inventory.txt");
           
                for (int i = 0; i < items.Count(); i++)
                {
                //5. Try Catch under SaveInventory
                    try
                    {
                  
                        write.Write($"{items[i][0]},");
                        write.Write($"{items[i][1]},");
                        write.Write($"{items[i][2]}");
                        write.WriteLine();
                         
                    }
                    catch(Exception e)
                    {
                    Console.WriteLine(e);
                    Console.WriteLine("This is under SaveInventory method");
                    Console.ReadKey();
                    }
                }
                write.Close();
            
        }
       
        public static void Display_Specific(string specific)
        { 
            string[] arrays = new string[3];
            int x = 1;
            Console.WriteLine("\n||LIST OF ITEMS UNDER THIS CATEGORY||");
            Console.WriteLine("\nFormat: [Name] , [Quantity], [Category]");
            Console.WriteLine();
            foreach (var item in items)
            {  
                //supply the value for array, these values came from the items list
                for (int i = 0; i < 3;)
                {
                    foreach (string val in item)
                    {
                        arrays[i] = val;
                        i++;
                    }
                }
                foreach (string values in arrays)
                {
                    if (values == specific)
                    {
                            check = false;
                            Console.Write($"{x})  ");
                            foreach (string val in arrays)
                            {
                                Console.Write($"{val}. ");
                            }
                            Console.WriteLine();
                            x++;
                         
                    }

                }
             
            }

        }

        //This Function display all the content of the List that has been copied to the txt file
        public static void Display_all()
        {
            Console.WriteLine("\n||LIST OF ALL ITEMS||");
            Console.WriteLine("\nFormat: [Name] , [Quantity], [Category]");
            int x = 1;
            //use to read the items on dimensional list
            foreach (var item in items)
            {
                //temporary array supply the value for display, these values came from the items list
                string[] arrays = new string[3];
                // 3 represent the total number of elements on the array(name,quant,category)
                for (int i = 0;  i < 3; i++)
                {
                    int y = 0;
                    //foreach value of the specific item in items, store it on the array. repeat thrice
                    foreach (string val in item)
                    {
                        arrays[y] = val;
                        y++;
                    }
                }
                //after the values is supplied on the array, use the for each for printing the content for that specific line in list
                Console.Write($"{x}) ");
                foreach (string values in arrays)
                {
                    Console.Write($"{values}, ");
                }
                Console.WriteLine();
                x++;
            }    
        }

        //this follow the same logic like on the display all method too tired to think and deadline is near
        public static void searchItem(string search)
        {
          
            string[] arrays = new string[3];
            int x = 1;
            Console.WriteLine("\n||SEARCH SUCCESFUL!||");
            Console.WriteLine("\nFormat: [Name] , [Quantity], [Category]");
            try
            {
                foreach (var item in items)
                {
                    //supply the value for array, these values came from the items list
                    for (int i = 0; i < 3;)
                    {
                        foreach (string val in item)
                        {
                            arrays[i] = val;
                            i++;
                        }
                    }
                    foreach (string values in arrays)
                    {
                        if (values.ToUpper() == search.ToUpper())
                        {
                            // exist true manipulates the global val exist. this means that the search is succesful
                            exist = true;
                            Console.Write($"{x})  ");
                            foreach (string val in arrays)
                            {
                                Console.Write($"{val}. ");
                            }
                            Console.WriteLine();
                            x++;
                        }

                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("No item has found");
                Console.WriteLine(e);
            }
            if (!exist)
            {
                Console.WriteLine("\nNothing has found");
            }
        }

        //2. Define a Struct for Inventory Items, this ovverides the string method for display
        public struct InventoryItems
        {
            string name;
            int quantity;
            ItemCategories item;
            public InventoryItems(string name, int quantity, ItemCategories item)
            {
                this.name = name;
                this.quantity = quantity;
                this.item = item;
            }
            public override string ToString()
            {
                return $"\n|THIS ITEM WILL BE SAVED IN YOUR INVENTORY|\n" +
                        $"\n ITEM NAME: {name}" +
                       $"\n ITEM QUANTITY: {quantity}" +
                       $"\n ITEM CATEGORY: {item} ";
            }
        }
    }

    //1. Define an Enum for Item Categories:
    public enum ItemCategories
    {
        Electronics = 0, Clothing = 1, Groceries = 2, Stationary = 3, Miscellaneous = 4
    }
}
