using _2_Claim_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _2_Claim_Console
{
    class ProgramUI
    {
        // New instance of the repository called _repo
        private ClaimRepository _repo = new ClaimRepository();

        // ID counter
        int counterID = 3;

        // Starter
        public void Run()
        {
            SeedClaimQueue();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to the user
                Console.WriteLine("KOMODO CLAIM DEPARTMENT\n\n" +
                    "1. View all claims.\n" +
                    "2. View next claim.\n" +
                    "3. Create a new claim.\n" +
                    "4. Exit.\n\n" +
                    "Select a menu option and press Enter:"
                    );

                // Get the user's input
                string userInput = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (userInput)
                {
                    case "1":
                        // View all claims in a queue
                        ViewAllClaimsQ();
                        break;
                    case "2":
                        // View next claim 
                        ViewNextClaimQ();
                        break;
                    case "3":
                        // Create a new claim in queue
                        CreateNewClaimQ();
                        break;
                    case "4":
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

        // View all claims in a Queue
        private void ViewAllClaimsQ()
        {
            Console.Clear();
            Console.WriteLine("KOMODO CLAIM DEPARTMENT\n" +
                "\n1. View all claims:\n");
            Queue<Claim> queueOfClaim = _repo.ReadClaimQueue();
            Console.WriteLine("ID  Type  Description  Amount  Date of Incident  Date of Claim  IsValid?");
            foreach (Claim claim in queueOfClaim)
            {
                Console.WriteLine($"{claim.ID}  {claim.Type}  {claim.Description}  {claim.Amount}  {claim.DateOfIncident.ToShortDateString()}  {claim.DateOfClaim.ToShortDateString()}  {claim.IsValid}");
            }
        }

        // View next claim in a Queue
        private void ViewNextClaimQ()
        {
            Console.Clear();
            Console.WriteLine("KOMODO CLAIM DEPARTMENT\n" +
                "\n2. View next claim:\n");
            Claim claim = _repo.NextClaimQ();
            Console.WriteLine($"ID: {claim.ID}\n" +
                $"Type: {claim.Type}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: {claim.Amount}\n" +
                $"Date of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {claim.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid?: {claim.IsValid}\n\n" +
                "Do you want to deal with this claim now (y/n)?"
                );
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    _repo.RemoveNextClaimQ();
                    ViewAllClaimsQ();
                    Console.WriteLine("\nThe claim was removed from queue.");
                    break;
                case "n":
                    ViewAllClaimsQ();
                    Console.WriteLine("\nThe claim was not removed from queue.");
                    break;
                default:
                    Console.WriteLine("Please, enter a valid option.");
                    break;
            }
        }


        // Create a new claim in a Queue
        private void CreateNewClaimQ()
        {
            Console.Clear();
            Console.WriteLine("KOMODO CLAIM DEPARTMENT\n" +
                            "\n2. Create a new claim:\n");
            Claim newClaim = new Claim();

            // ID
            counterID++;
            newClaim.ID = counterID;
            Console.WriteLine($"New claim's ID:\n" +
                $"{newClaim.ID}");

            // Type
            Console.WriteLine("Enter the type for the claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft"
                );
            // Type validation
            bool keepAskingType = true;
            while (keepAskingType)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    int typeAsInt = int.Parse(userInputAsString);
                    newClaim.Type = (KindOfType)typeAsInt;
                    keepAskingType = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Description
            Console.WriteLine("Enter the description for the claim:");
            // Description validation
            bool keepAskingDescription = true;
            while (keepAskingDescription)
            {
                string userInputAsString = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInputAsString))
                {
                    newClaim.Description = userInputAsString;
                    keepAskingDescription = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Amount
            Console.WriteLine("Enter the amount for the claim:");
            // Amount validation
            bool keepAskingAmount = true;
            while (keepAskingAmount)
            {
                string userInputAsString = Console.ReadLine();
                if (double.TryParse(userInputAsString, out double claimAmount) && claimAmount > 0)
                {
                    newClaim.Amount = claimAmount;
                    keepAskingAmount = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Date of Incident
            Console.WriteLine("Enter the incident's date for the claim (yyyy/mm/dd):");
            // Date of Incident validation
            bool keepAskingDateOfIncident = true;
            while (keepAskingDateOfIncident)
            {
                string userInputAsString = Console.ReadLine();
                if (DateTime.TryParse(userInputAsString, out DateTime dateOfIncident) && dateOfIncident < DateTime.Now)
                {
                    newClaim.DateOfIncident = dateOfIncident;
                    keepAskingDateOfIncident = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Date of Claim
            Console.WriteLine("Enter the claim's date (yyyy/mm/dd):");
            // Date of Claim validation
            bool keepAskingDateOfClaim = true;
            while (keepAskingDateOfClaim)
            {
                string userInputAsString = Console.ReadLine();
                if (DateTime.TryParse(userInputAsString, out DateTime dateOfClaim) && dateOfClaim < DateTime.Now)
                {
                    newClaim.DateOfClaim = dateOfClaim;
                    keepAskingDateOfClaim = false;
                }
                else
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }

            // Validity
            double periodAsDouble = (newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays;
            int periodOfDays = Convert.ToInt32(periodAsDouble);
            Console.WriteLine("Is claim valid?:");
            if (periodOfDays <= 30)
            {
                newClaim.IsValid = true;
                Console.WriteLine(true);
            }
            else
            {
                newClaim.IsValid = false;
                Console.WriteLine(false);
            }

            // Adding to repository
            _repo.CreateClaimQ(newClaim);
        }


        // Seed information
        private void SeedClaimQueue()
        {
            DateTime dateOfIncident1 = new DateTime(2018, 4, 25);
            DateTime dateOfClaim1 = new DateTime(2018, 4, 27);
            Claim carAccident = new Claim(1, (KindOfType)1, "Car accident on 465.", 400.55, dateOfIncident1, dateOfClaim1, true);
            _repo.CreateClaimQ(carAccident);

            DateTime dateOfIncident2 = new DateTime(2018, 4, 11);
            DateTime dateOfClaim2 = new DateTime(2018, 4, 12);
            Claim houseFire = new Claim(2, (KindOfType)2, "House fire in kitchen.", 4000.28, dateOfIncident2, dateOfClaim2, true);
            _repo.CreateClaimQ(houseFire);

            DateTime dateOfIncident3 = new DateTime(2018, 4, 27);
            DateTime dateOfClaim3 = new DateTime(2018, 6, 01);
            Claim stolenPancakes = new Claim(3, (KindOfType)3, "Stolen pancakes.", 4.85, dateOfIncident3, dateOfClaim3, false);
            _repo.CreateClaimQ(stolenPancakes);
        }
    }
}
