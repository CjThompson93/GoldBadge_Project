using KomodoIns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Console
{

    public class ProgramUI
    {

        static void Main()
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
        private ClaimsRepo _repo = new ClaimsRepo();
        public void Run()
        {
            SeedClaims();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private bool Menu()
        {
            Console.WriteLine("KomodoInsurance--MainMenu--");
            Console.WriteLine("Please select number of the option you would like:\n\n" +
                "1. Display All Claims\n" +
                "2. Accept Next Claim\n" +
                "3. Add New Claim\n" +
                "4. Search Claim By Claim Number\n" +
                "5. Update Exisiting Claim By Claim Number\n" +
                "6. Exit");

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    AcceptNextClaim();
                    break;
                case "3":
                    AddNewClaim();
                    break;
                case "4":
                    SearchClaimByClaimNumber();
                    break;
                case "5":
                    UpdateExisitingClaimByClaimNumber();
                    break;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Please enter a vaild number (1-6) \n");
                    return true;
            }
            return true;
        }
        //Menu Method
        private void DisplayAllClaims()
        {
            Console.Clear();

            foreach (var item in _repo.GetAllClaimsFromQueue())
            {
                DisplayAllClaims(item);
            }
        }
        private void AcceptNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Next claim in queue order.");
            var firstQueueClaim = _repo.PeekClaimFromQueue();
            DisplayAllClaims(firstQueueClaim);
            Console.WriteLine("Would you like to deal with this claim now?\n" +
                "Please enter y for yes or n for no.");

            if (_repo.DequeueFirstClaim(Console.ReadLine().ToLower()))
            {
                Console.WriteLine("You have accepted the claim.\n");
            }
            else
            {
                Console.WriteLine("You have denied this claim.\n");
            }
        }
        private void AddNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Adding a new claim");

            ClaimsContent newClaim = GetValuesForClaimObjects();

            if (_repo.AddClaimToDirectory(newClaim))
            {
                Console.WriteLine("You have added a new claim successfully!\n");
            }
            else
            {
                Console.WriteLine("We are unable to add this claim sorry for the inconvenience.\n");
            }
        }
        private void SearchClaimByClaimNumber()
        {
            Console.Clear();
            Console.WriteLine("Search for a claim by its claim number.");
            DisplayAllClaims();

            Console.WriteLine("Please enter claim number you are searching for:\n");

            ClaimsContent claim = _repo.GetClaimsFromQueueById(Convert.ToInt32(Console.ReadLine()));

            if (_repo.GetClaimsFromQueueById(claim.ClaimId) != null)
            {
                Console.Clear();
                DisplayAllClaims(claim);
            }
            else
            {
                Console.WriteLine("We are sorry there are no claims with that number!");
            }
        }
        private void UpdateExisitingClaimByClaimNumber()
        {
            Console.Clear();
            Console.WriteLine("Updating claims");
            DisplayAllClaims();
            Console.WriteLine("Please enter the claim number you would like to update:\n");

            ClaimsContent oldClaim = _repo.GetClaimsFromQueueById(Convert.ToInt32(Console.ReadLine()));

            if (_repo.UpdateExistingClaimById(oldClaim.ClaimId, GetValuesForClaimObjects()))
            {
                Console.WriteLine("You have successfully updated the claim!\n");
            }
            else
            {
                Console.WriteLine("The claim was NOT updated successfully!\n");
            }
        }

        //Helper Methods
        private ClaimsContent GetValuesForClaimObjects()
        {
            Console.WriteLine("Please enter the claim number:\n");
            int claimId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the claim number corrosponding to the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            ClaimType typeOfClaim = (ClaimType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the claim description:\n");
            string description = Console.ReadLine();

            Console.WriteLine("Please enter the amount of damage or lost:\n");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please enter the date of the incident (YYYY/MM/DD):\n");
            DateTime dateIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the claim (YYYY/MM/DD):\n");
            DateTime dateClaim = DateTime.Parse(Console.ReadLine());

            ClaimsContent claim = new ClaimsContent(claimId, typeOfClaim, description, amount, dateIncident, dateClaim);
            return claim;
        }
        private void DisplayAllClaims(ClaimsContent content)
        {
            var amountAsString = content.ClaimAmount.ToString("0,000.00");

            Console.WriteLine($"Claim ID: {content.ClaimId}\n" +
                $"Type: {content.TypeOfClaim}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: ${amountAsString}\n" +
                $"Date of Incident: {content.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {content.DateOfClaim.ToShortDateString()}\n" +
                $"{content.Valid()}\n");
        }

        private void SeedClaims()
        {
            _repo.AddClaimToDirectory(new ClaimsContent(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27)));
            _repo.AddClaimToDirectory(new ClaimsContent(2, ClaimType.Home, "house fire in the kitchen", 400000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12)));
            _repo.AddClaimToDirectory(new ClaimsContent(3, ClaimType.Theft, "Stolen Abyssal Whip", 1848721m, new DateTime(2021, 10, 04), new DateTime(2021, 10, 05)));
        }
    }
}
