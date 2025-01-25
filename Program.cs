// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
using Mission3Assignment;

class Program
//The program is what will prompt the user to choose actions until they choose to exit
//It possesses an iterative flow
{
    static void Main(string[] args)
    //The list contains strings that describe each item in the inventory. This will exist as dynamic list management. 
    {
        List<FoodItem> inventory = new List<FoodItem>();
        bool running = true;

        System.Console.WriteLine("Hello, welcome to our local Food Bank Inventory System!");

        while (running)
        //Each line will be printed for the user to make their choice
        {
            System.Console.WriteLine("\nMenu");
            System.Console.WriteLine("1. Add Food Items");
            System.Console.WriteLine("2. Delete Food Items");
            System.Console.WriteLine("3. Print List of Current Food Items in Our Inventory");
            System.Console.WriteLine("4. Exit the Program");
            System.Console.WriteLine("Choose an option (1-4): ");

            //The user's choice will be read and processed through the series of cases below 
            //This program has four cases that that allows the user to add, delete, print inventory, and ultimately exit the program 
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFoodItem(inventory);
                    break;
                case "2":
                    DeleteFoodItem(inventory);
                    break;
                case "3":
                    PrintInventory(inventory);
                    break;
                case "4":
                    running = false;
                    System.Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    System.Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    //The user will be able to add food items and provide details each that will be read and stored
    static void AddFoodItem(List<FoodItem> inventory)
    {
        try
        {
            System.Console.WriteLine("Enter the name of the food item (e.g., \"Canned Beans\"): ");
            string name = System.Console.ReadLine();

            System.Console.WriteLine("Enter the category of the food item (e.g., \"Canned Goods\", \"Dairy\", \"Produce\"): ");
            string category = System.Console.ReadLine();

            System.Console.WriteLine("Enter the quantity (e.g., 15 units): ");
            int quantity = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Enter the experiation date (MM/DD/YYYY): ");
            DateTime expirationDate = DateTime.Parse(System.Console.ReadLine());

            // Attempt to create a new FoodItem (constructor handles validation) 
            FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
            inventory.Add(newItem);

            System.Console.WriteLine("Food item added successfully!");
        }
        //Error handling must be utilized to handle invalid inputs that will redirect the user to input the correct info upon request
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input format. Please enter a number for quantity and a valid date.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception)
        {
            Console.WriteLine("An unexpected error occurred. Please try again.");
        }
    }

    //The user will be able to delete food items. If there are 0 items, a message will be returned informing the user that there is nothing to delete 
    //The user can delete an item by name specifically
    static void DeleteFoodItem(List<FoodItem> inventory)
    {
        if (inventory.Count == 0)
        {
            System.Console.WriteLine("No items to delete.");
            return;
        }

        System.Console.WriteLine("Enter the name of the food item to delete:");
        string name = System.Console.ReadLine();

        FoodItem itemToRemove = inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (itemToRemove != null)
        {
            inventory.Remove(itemToRemove);
            System.Console.WriteLine("Food item deleted successfully!");
        }
        else
        {
            System.Console.WriteLine("Food item not found.");
        }
    }

    //All items in the food bank inventory will be printed according to the structure outlined in the food item class
    static void PrintInventory(List<FoodItem> inventory)
    {
        if (inventory.Count == 0)
        {
            System.Console.WriteLine("No items in inventory.");
            return;
        }

        System.Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            System.Console.WriteLine(item);
        }
    }
}



