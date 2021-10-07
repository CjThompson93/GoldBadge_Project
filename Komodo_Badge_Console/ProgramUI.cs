using Komodo_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badge_Console
{
    class ProgramUI
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
        private BadgeRepo _repo = new BadgeRepo();
        public void Run()
        {
            SeedBadges();
            while (Menu())
            {
                Console.WriteLine("Press any key to continue..\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private bool Menu()
        {
            Console.WriteLine("Main Menu\n\n");

            Console.WriteLine("Please enter the number of the selection you would like to do:\n" +
                "1. Add a Badge \n" +
                "2. Edit a Badge\n" +
                "3. List All Badges\n" +
                "4. Exit");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AddBadge();
                    break;
                case 2:
                    EditBadge();
                    break;
                case 3:
                    ListAllBadges();
                    break;
                case 4:
                    return false;
                default:
                    Console.WriteLine("Please enter a vaild number between (1-4)\n");
                    return true;
            }
            return true;
        }
        private void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("Add a new badge.\n");

            Console.WriteLine("Please enter the number of the badge:");
            int badgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please list the first door that the badge needs access to, and then press any key to continue:\n");
            string response = Console.ReadLine().ToUpper();
            List<string> listResponse = new List<string> { response };

            bool keepAsking = true;
            while (keepAsking)
            {
                Console.WriteLine("Please enter additional doors y for yes n for no:\n");
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse == "yes" || userResponse == "y")
                {
                    Console.WriteLine("Please list any other doors that the badge needs access to:\n");
                    string addDoor = Console.ReadLine().ToUpper();
                    listResponse.Add(addDoor);
                }
                else if (userResponse == "no" || userResponse == "n")
                {
                    keepAsking = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.\n");
                }
            }
            BadgeContent newBadge = new BadgeContent(badgeID, listResponse);
            if (_repo.AddBadgeToDictionary(newBadge))
            {
                Console.WriteLine("You have successfully added a new badge.\n");
            }
            else
            {
                Console.WriteLine("We apologise this badge was not successfully added.\n");
            }
        }
        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Editing badges\n");

            while (RemoveOrAddDoorMenu())
            {
                Console.WriteLine("Press any key to continue..\n");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Please edit the badge information.\n");
            }
        }

        private bool RemoveOrAddDoorMenu()
        {
            Console.WriteLine("Please enter the number you would like.\n" +
                "1. Add door to badges.\n" +
                "2. Remove doors from badges.\n" +
                "3. See a list of badges.\n" +
                "4. Back to menu.\n");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                EditAddDoor();
                return true;
            }
            else if (input == 2)
            {
                EditRemoveDoor();
                return true;
            }
            else if (input == 3)
            {
                ListAllBadges();
                return true;
            }
            else if (input == 4)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter a vaild number between 1-4\n");
                return true;
            }
        }
        private void EditAddDoor()
        {
            Console.Clear();
            Console.WriteLine("Add a door to the badge.\n");

            Console.WriteLine("Please enter the badge id number:\n");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            var dict = _repo.GetBadgeList();

            if (dict.ContainsKey(badgeID))
            {
                foreach (var badge in dict.OrderBy(key => key.Key))
                {
                    if (badge.Key == badgeID)
                    {
                        int firstCount = badge.Value.Count;

                        var list = badge.Value;
                        var valueAsString = string.Join(", ", list);
                        Console.WriteLine($"Badge ID {badge.Key} has access to doors: {valueAsString}.\n");

                        Console.WriteLine("Please enter the door you would like to add to the badge.:\n");
                        string additionDoor = Console.ReadLine().ToUpper();
                        badge.Value.Add(additionDoor);

                        int secondCount = badge.Value.Count;
                        var list2 = badge.Value;
                        list2.Sort();
                        var valueAsStringAgain = string.Join(", ", list2);

                        if (secondCount > firstCount)
                        {
                            Console.WriteLine($"Door was added successfully.\n");
                            Console.WriteLine($"Badge ID {badge.Key} has access to doors: {valueAsStringAgain}.\n");
                        }
                        else
                        {
                            Console.WriteLine("We apologize the door was not added successfully.\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("This badge is not saved.\n");
            }
        }
        private void EditRemoveDoor()
        {
            Console.Clear();
            Console.WriteLine("Remove a door from a badge.\n");

            Console.WriteLine("Please enter the badge id:\n");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            var dict = _repo.GetBadgeList();

            if (dict.ContainsKey(badgeID))
            {
                foreach (var badge in dict.OrderBy(key => key.Key))
                {
                    if (badge.Key == badgeID)
                    {
                        int firstCount = badge.Value.Count;

                        var list = badge.Value;
                        var valueAsString = string.Join(", ", list);
                        Console.WriteLine($"Badge ID {badge.Key} has access to doors: {valueAsString}.\n");

                        Console.WriteLine("Please enter the door you would like to remove form the badge.\n");
                        string additionDoor = Console.ReadLine().ToUpper();
                        badge.Value.Remove(additionDoor);

                        int secondCount = badge.Value.Count;
                        var list2 = badge.Value;
                        list2.Sort();
                        var valueAsStringAgain = string.Join(", ", list2);

                        if (secondCount < firstCount)
                        {
                            Console.WriteLine($"The door has been successfully removed.\n");
                            Console.WriteLine($"Badge ID {badge.Key} has access to doors: {valueAsStringAgain}.\n");
                        }
                        else
                        {
                            Console.WriteLine("We apologize the door was not successfully removed.\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("This badge is not saved.");
            }
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("List of Badges.\n");
            var dict = _repo.GetBadgeList();
            if (dict.Count > 0)
            {
                foreach (var badge in dict.OrderBy(key => key.Key))
                {
                    var list = badge.Value;
                    list.Sort();
                    var valueAsString = string.Join(", ", list);
                    Console.WriteLine($"Badge ID {badge.Key} has access to doors: {valueAsString}.\n");
                }
            }
        }
        private void SeedBadges()
        {
            _repo.AddBadgeToDictionary(new BadgeContent(12345, new List<string> { "A7" }));
            _repo.AddBadgeToDictionary(new BadgeContent(22345, new List<string> { "A1", "A4", "B1", "B2" }));
            _repo.AddBadgeToDictionary(new BadgeContent(32345, new List<string> { "A4", "A5", }));
        }
    }
}
