using _3_Badge_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Badge_Console
{
    class ProgramUI
    {
        // New instance of the repository called _repo
        private BadgeRepository _repo = new BadgeRepository();

        // ID counter
        int counterID = 32345;

        // Starter
        public void Run()
        {
            SeedInfo();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to the user
                Console.WriteLine("KOMODO BADGES\n\n" +
                    "1. View all badges and doors.\n" +
                    "2. View a badge by ID.\n" +
                    "3. Create a new badge.\n" +
                    "4. Update doors on a badge by ID.\n" +
                    "5. Delete all doors on a badge by ID.\n" +
                    "6. Exit.\n\n" +
                    "Select a menu option and press Enter:"
                    );

                // Get the user's input
                string userInput = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (userInput)
                {
                    case "1":
                        // View all badges and doors.
                        ViewAllBadges();
                        break;
                    case "2":
                        // View a badge by ID 
                        ViewBadgeByID();
                        break;
                    case "3":
                        // Create a badge
                        CreateBadge();
                        break;
                    case "4":
                        // Update doors on a badge by ID
                        UpdateBadgeByID();
                        break;
                    case "5":
                        // Delete all doors on a badge by ID
                        DeleteBadgeByID();
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
                Console.ReadKey();
                Console.Clear();
            }
        }

        // View all badges and doors
        private void ViewAllBadges()
        {
            Console.Clear();
            Console.WriteLine("KOMODO BADGES\n" +
                "\n1. View all badges and doors:\n");

            Dictionary<int, Badge> dictionaryOfBadge = _repo.ReadAllBadge();

            foreach (var badge in dictionaryOfBadge) 
            {
                Console.WriteLine($"Badge ID: {badge.Value.BadgeID} Name: {badge.Value.Name} Doors: {string.Join(", ", badge.Value.ListOfDoors.ToArray())}");
            }
        }

        // View a badge by ID 
        private void ViewBadgeByID()
        {
            ViewAllBadges();
            Console.WriteLine("\n2. View a badge by ID:\n");
            Console.WriteLine("Enter the badge's ID you would like to see:");
            // ID validation
            bool keepAskingID = true;
            while (keepAskingID)
            {
                string userInputAsString = Console.ReadLine();
                if (int.TryParse(userInputAsString, out int userInput))
                {
                    Badge badge = _repo.ReadBadgeByID(userInput);
                    if (badge != null)
                    {
                        Console.WriteLine($"\nID: {badge.BadgeID}\n" +
                            $"Name: {badge.Name}\n" +
                            $"Doors: {string.Join(", ", badge.ListOfDoors.ToArray())}");
                        keepAskingID = false;
                    }
                    else
                    {
                        Console.WriteLine("No badge by that ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }
        }

        // Create a badge
        private void CreateBadge()
        {
            Badge newBadge = new Badge();

            // ID
            counterID++;
            newBadge.BadgeID = counterID;
            Console.WriteLine($"\nNew badge ID:\n" +
                $"{newBadge.BadgeID}");

            // Name
            Console.WriteLine("Enter the name for the badge.");
            // Name validation
            bool keepAskingName = true;
            while (keepAskingName)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    newBadge.Name = userInputAsString;
                    keepAskingName = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Doors
            Console.WriteLine("Enter the doors for the badge or 'X' to finish:");
            // Doors validation
            bool keepAddingDoors = true;
            while (keepAddingDoors)
            {
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "":
                        Console.WriteLine("Please, enter a valid option.");
                        break;
                    case "X":
                        keepAddingDoors = false;
                        break;
                    default:
                        newBadge.ListOfDoors.Add(userInput);
                        break;
                }
            }

            // Adding to repository
            _repo.CreateBadge(newBadge.BadgeID, newBadge);  // Asigning the BadgeID equal to the entry number in the dictionary
        }

        // Update doors on a badge by ID
        private void UpdateBadgeByID()
        {
            ViewAllBadges();
            Console.WriteLine("\n4. Update an existing badge by ID:\n");
            Console.WriteLine("Enter the badge's ID you would like to update.");

            int oldBadge = 0;

            // ID validation
            bool keepAskingID = true;
            while (keepAskingID)
            {
                string userInputAsString = Console.ReadLine();
                if (int.TryParse(userInputAsString, out int userInput))
                {
                    oldBadge = userInput;
                    keepAskingID = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            Badge newBadge = new Badge();
            newBadge.BadgeID = oldBadge;

            // Name
            Console.WriteLine("Enter the name for the badge:");
            // Name validation
            bool keepAskingName = true;
            while (keepAskingName)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    newBadge.Name = userInputAsString;
                    keepAskingName = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            Console.WriteLine("Enter the doors for the badge or 'X' to finish:");
            // Doors validation 
            bool keepAddingDoors = true;
            while (keepAddingDoors)
            {
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "":
                        Console.WriteLine("Please, enter a valid option.");
                        break;
                    case "X":
                        keepAddingDoors = false;
                        break;
                    default:
                        newBadge.ListOfDoors.Add(userInput);
                        break;
                }
            }
            
            // Updating in repository
            _repo.UpdateBadge(oldBadge, newBadge);
        }

        // Delete all doors on a badge by ID
        private void DeleteBadgeByID()
        {
            ViewAllBadges();
            Console.WriteLine("\n5. Delete a badge by ID:\n");
            Console.WriteLine("Enter the badge's ID you would like to delete:");
            // ID validation
            bool keepAskingID = true;
            while (keepAskingID)
            {
                string userInputAsString = Console.ReadLine();
                if (int.TryParse(userInputAsString, out int userInput))
                {
                    // Check if Delete worked
                    bool wasDeleted = _repo.DeleteBadge(userInput);
                    if (wasDeleted)
                    {
                        ViewAllBadges();
                        Console.WriteLine("\nThe badge was succesfully deleted.");
                        keepAskingID = false;
                    }
                    else
                    {
                        ViewAllBadges();
                        Console.WriteLine("\nThe badge could not be deleted.");
                    }
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }
        }

        // Seed Info
        private void SeedInfo()
        {
            List<string> developerDoors = new List<string> { "A7" };
            Badge developer = new Badge(12345, developerDoors, "Developer");
            _repo.CreateBadge(12345, developer);

            List<string> claimAgentDoors = new List<string> { "A1", "A4", "B1", "B2" };
            Badge claimAgent = new Badge(22345, claimAgentDoors, "Claim Agent");
            _repo.CreateBadge(22345, claimAgent);

            List<string> accountantDoors = new List<string> { "A4", "A5" };
            Badge accountant = new Badge(32345, accountantDoors, "Accountant");
            _repo.CreateBadge(32345, accountant);

        }
    }
}
