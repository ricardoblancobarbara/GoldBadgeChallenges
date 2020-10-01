using _1_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1_Cafe_Console
{
    class ProgramUI
    {
        // New instance of the repository called _repo
        private MealRepository _repo = new MealRepository();

        // ID counter
        int counterID = 3;

        // Starter
        public void Run()
        {
            SeedMealList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to the user
                Console.WriteLine("KOMODO CAFE\n\n" +
                    "1. Create a new meal.\n" +
                    "2. View all meals.\n" +
                    "3. View a meal by ID.\n" +
                    "4. Update an existing meal.\n" +
                    "5. Delete an existing meal.\n" +
                    "6. Exit.\n\n" +
                    "Select a menu option and press Enter:"
                    );

                // Get the user's input
                string userInput = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (userInput)
                {
                    case "1":
                        // Create a new meal
                        CreateNewMeal();
                        break;
                    case "2":
                        // View all meals
                        ViewAllMeals();
                        break;
                    case "3":
                        // View a meal by ID
                        ViewMealByID();
                        break;
                    case "4":
                        // Update a meal by ID
                        UpdateMealByID();
                        break;
                    case "5":
                        // Delete a meal by ID
                        DeleteMealByID();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        // Invalid option
                        Console.WriteLine("Please, enter a valid option.");
                        break;
                }                
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // Create a new meal
        private void CreateNewMeal()
        {
            Console.Clear();
            Console.WriteLine("KOMODO CAFE\n" +
                            "\n2. Create a new meal:\n");
            Meal newMeal = new Meal();

            // ID
            counterID++;
            newMeal.ID = counterID;
            Console.WriteLine($"New meals ID:\n" +
                $"{newMeal.ID}");

            // Name
            Console.WriteLine("Enter the name for the meal:");
            // Name validation
            bool keepAskingName = true;
            while (keepAskingName)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    newMeal.Name = userInputAsString;
                    keepAskingName = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Description
            Console.WriteLine("Enter the description for the meal:");
            // Description validation
            bool keepAskingDescription = true;
            while (keepAskingDescription)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    newMeal.Description = userInputAsString;
                    keepAskingDescription = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Ingredients
            Console.WriteLine("Enter the ingredients for the meal or 'F' to finish:");
            // Ingredients validation
            bool keepAddingIngredients = true;
            while (keepAddingIngredients)
            {                
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "":
                        Console.WriteLine("Please, enter a valid option.");
                        break;
                    case "f":
                        keepAddingIngredients = false;
                        break;
                    default:
                        newMeal.Ingredients.Add(userInput);
                        break;
                }
            }

            // Price
            Console.WriteLine("Enter the price for the meal:");
            // Price validation
            bool keepAskingPrice = true;
            while (keepAskingPrice)
            {
                string userInputAsString = Console.ReadLine();
                if (double.TryParse(userInputAsString, out double priceInput) && priceInput > 0)
                {
                    newMeal.Price = priceInput;
                    keepAskingPrice = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Adding to repository
            bool wasCreated = _repo.AddMealToList(newMeal);
            if (wasCreated)
            {
                ViewAllMeals();
                Console.WriteLine("\nThe meal was succesfully created.");
            }
            else
            {
                ViewAllMeals();
                Console.WriteLine("\nThe meal could not be created.");
            }
        }

        // View all meals
        private void ViewAllMeals()
        {
            Console.Clear();
            Console.WriteLine("KOMODO CAFE\n" +
                "\n2. View all meals:\n");
            List<Meal> listOfMeal = _repo.GetMealList();
            foreach(Meal meal in listOfMeal)
            {
                Console.WriteLine($"ID: {meal.ID} Name: {meal.Name}");
            }
        }

        // View a meal by ID
        private void ViewMealByID()
        {
            ViewAllMeals();
            Console.WriteLine("\n3. View a meal by ID:\n");
            Console.WriteLine("Enter the meal's ID you would like to see:");
            // ID validation
            bool keepAskingID = true;
            while (keepAskingID)
            {
                string userInputAsString = Console.ReadLine();
                if (int.TryParse(userInputAsString, out int userInput))
                {
                    Meal meal = _repo.GetMealByID(userInput);
                    if (meal != null)
                    {
                        Console.WriteLine($"\nID: {meal.ID}\n" +
                            $"Name: {meal.Name}\n" +
                            $"Description: {meal.Description}\n" +
                            $"Ingredients: {string.Join(", ", meal.Ingredients.ToArray())}\n" +
                            $"Price: {meal.Price}");
                        keepAskingID = false;
                    }
                    else
                    {
                        Console.WriteLine("No meal by that ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }
        }

        // Update a meal by ID
        private void UpdateMealByID()
        {
            ViewAllMeals();
            Console.WriteLine("\n4. Update an existing meal by ID:\n");
            Console.WriteLine("Enter the meal's ID you would like to update.");
            int oldMeal = 0;
            // ID validation
            bool keepAskingID = true;
            while (keepAskingID)
            {
                string userInputAsString = Console.ReadLine();
                if (int.TryParse(userInputAsString, out int userInput))
                {
                    oldMeal = userInput;
                    keepAskingID = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            Meal newMeal = new Meal();
            newMeal.ID = oldMeal;

            Console.WriteLine("Enter the name for the meal:");
            // Name validation
            bool keepAskingName = true;
            while (keepAskingName)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    newMeal.Name = userInputAsString;
                    keepAskingName = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            Console.WriteLine("Enter the description for the meal:");
            // Description validation
            bool keepAskingDescription = true;
            while (keepAskingDescription)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    newMeal.Description = userInputAsString;
                    keepAskingDescription = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            Console.WriteLine("Enter the ingredients for the meal or 'F' to finish:");
            // Ingredients validation 
            bool keepAddingIngredients = true;
            while (keepAddingIngredients)
            {
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "":
                        Console.WriteLine("Please, enter a valid option.");
                        break;
                    case "f":
                        keepAddingIngredients = false;
                        break;
                    default:
                        newMeal.Ingredients.Add(userInput);
                        break;
                }
            }

            Console.WriteLine("Enter the price for the meal:");
            // Price validation
            bool keepAskingPrice = true;
            while (keepAskingPrice)
            {
                string userInputAsString = Console.ReadLine();
                if (double.TryParse(userInputAsString, out double priceInput) && priceInput > 0)
                {
                    // Check if Update worked
                    newMeal.Price = priceInput;
                    bool wasUpdated = _repo.UpdateMealByID(oldMeal, newMeal);
                    if (wasUpdated)
                    {
                        ViewAllMeals();
                        Console.WriteLine("\nThe meal was successfully updated.");
                    }
                    else
                    {
                        ViewAllMeals();
                        Console.WriteLine("\nThe meal could not be updated.");
                    }
                    keepAskingPrice = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }
            // Updating in repository
            _repo.UpdateMealByID(oldMeal, newMeal);

        }

        // Delete a meal by ID
        private void DeleteMealByID()
        {            
            ViewAllMeals();
            Console.WriteLine("\n5. Delete a meal by ID:\n");
            Console.WriteLine("Enter the meal's ID you would like to delete:");
            // ID validation
            bool keepAskingID = true;
            while (keepAskingID)
            {
                string userInputAsString = Console.ReadLine();
                if (int.TryParse(userInputAsString, out int userInput))
                {
                    // Check if Delete worked
                    bool wasDeleted = _repo.DeleteMealByID(userInput);
                    if (wasDeleted)
                    {
                        ViewAllMeals();
                        Console.WriteLine("\nThe meal was succesfully deleted.");
                        keepAskingID = false;
                    }
                    else
                    {
                        ViewAllMeals();
                        Console.WriteLine("\nThe meal could not be deleted.");
                    }
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }
        }

        // Seed Method
        private void SeedMealList()
        {            
            List<string> royaleIngredients = new List<string> {"double burger", "burger buns", "american cheese", "bacon", "lettuce", "tomato", "egg" };
            Meal royale = new Meal(1, 
                "Royale", 
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" +
                "lettuce, vine-ripened tomato, and top with a fried egg and mayonnaise.", 
                royaleIngredients, 
                3.5);
            _repo.AddMealToList(royale);
            
            List<string> westernBBQIngredients = new List<string> {"double burger", "burger buns", "american cheese", "bacon", "onions", "barbecue sauce"};
            Meal westernBBQ = new Meal(2, 
                "Western BBQ and Bacon", 
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" + 
                "diced and fried onions, and sweet and smoky BBQ sauce.", 
                westernBBQIngredients, 
                3.8);
            _repo.AddMealToList(westernBBQ);

            List<string> grilledPortobelloIngredients = new List<string> {"double burger", "burguer buns", "swiss cheese", "onions", "garlic mayonnaise"};
            Meal grilledPortobello = new Meal(3, 
                "Grilled Portobello and Swiss Cheese", 
                "Double burger with fresh portobello mushrooms, Swiss cheese, caramelized onions and garlic mayonnaise.", 
                grilledPortobelloIngredients, 
                3.9);
            _repo.AddMealToList(grilledPortobello);
        }
    }
}


