// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic; //Use this for the list


namespace Assignment3_Blas
{
    class Program
    {
        //Main method to run the program------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            //We make a new list called inventory with the class in FoodItem.cs. (Also, set a boolean as false so we can stay in the loop.
            List<FoodItem> inventory = new List<FoodItem>();
            bool exit = false;

            //Make a while loop to and make an action selection
            while (!exit)
            {
                Console.WriteLine("\n--- Food Bank Inventory System ---");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine(); //Set the choice variable with user unput

                switch (choice) //switch is kind of like an if then statement, but lowkey easier. 
                    // Each case runs one of the methods below
                {
                    case "1":
                        AddFoodItem(inventory);
                        break;
                    case "2":
                        DeleteFoodItem(inventory);
                        break;
                    case "3":
                        PrintFoodItems(inventory);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again."); //Error handling
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        //Method for adding a food item-------------------------------------------------------------------
        static void AddFoodItem(List<FoodItem> inventory)
        {
            Console.Write("Enter food name: ");
            string name = Console.ReadLine();

            Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
            string category = Console.ReadLine();

            int quantity;
            while (true) //You can just make a loop true until you break it. 
            {
                //Make sure quantity is a realistic number
                Console.Write("Enter quantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
            }

            DateTime expirationDate;
            while (true) 
            {
                //Make sure the expiration date is a day that actually makes sense to have in the future. Otherwise you probably would have thrown it away lol
                Console.Write("Enter expiration date (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out expirationDate) && expirationDate > DateTime.Now)
                {
                    break;
                }
                Console.WriteLine("Invalid date. Please enter a valid future date in the format YYYY-MM-DD.");
            }

            //This passes the variables the user just filled in to the FoodItem method to create a new item that can be added to the list
            FoodItem foodItem = new FoodItem(name, category, quantity, expirationDate); //The first FoodItem is the class. The second is the object being made. The third is the method used to make the object.
            inventory.Add(foodItem); 
            Console.WriteLine("Food item added successfully!");
        }

        //Method to delete an item------------------------------------------------------------------------------------------------------------
        static void DeleteFoodItem(List<FoodItem> inventory)
        {
            //Don't let the user delete items if there aren't any
            if (inventory.Count == 0)
            {
                Console.WriteLine("No food items to delete.");
                return;
            }

            //Show the list of food items in the pantry
            Console.WriteLine("\nCurrent Food Items:");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i]}");
            }

            int index; //This variable is for the user input
            while (true)
            {
                Console.Write("Enter the number of the food item to delete: ");

                //The line below this makes sure it's in range. It's better than making it directly equal to whatever selection they pick.
                if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= inventory.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid selection. Please try again.");
            }

            //Make sure to add -1 or you'll remove the wrong one
            inventory.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully!");
        }

        //Method to print items in the list----------------------------------------------------------------------------------------------------------
        static void PrintFoodItems(List<FoodItem> inventory)
        {
            //Make sure there's actually something in the pantry
            if (inventory.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
                return;
            }

           //(To my knowledge, var just sort of infers or guesses the variable type.)

           //Print each foodItem in the inventory list
            Console.WriteLine("\n--- Current Food Items ---");
            foreach (var foodItem in inventory)
            {
                //IMPORTANT:: When you call an item from a list, it uses ToString() which makes it basically unreadable.
                //That's why you'll see ToString() overwritten in FoodItem.cs. That way, it presents the way it should. 
                Console.WriteLine(foodItem); 
            }
        }
    }
}

