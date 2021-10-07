using Komodo_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class ProgramUI
    {
        static void Main() 
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
        
            private MenuContentRepo _menuRepo = new MenuContentRepo();
        
            public void Run()
            {
                SeedData();

                RunMenu();
            }

            private void RunMenu()
            {
                bool isRunning = true;
                while (isRunning)
                {
                    Console.Clear();

                    Console.WriteLine
                        (
                            "Please select the number of you're request:\n" +
                            "1. Create new menu selections:\n" +
                            "2. View all menu options:\n" +
                            "3. Update menu options:\n" + 
                            "4. Remove any menu options:\n" +
                            "5. Exit the system"
                        );
                    string userIntput = Console.ReadLine();

                    switch (userIntput)
                    {
                        case "1":
                            //Creating menu selections
                            CreateNewMenu();
                            break;
                        case "2":
                            //Show all menu options
                            ShowAllMenu();
                            break;
                        case "3":
                            //Update menu options
                            UpdateMenu();
                            break;
                        case "4":
                            //Delete menu options
                            RemoveContentFromMenu();
                            break;
                        case "5":
                            //Exit the system
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid number between 1 and 5\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                        break;
                    }

                }
            }

        //Creating menu options 
        private void CreateNewMenu()
        {
            Console.Clear();

            MenuContent menu = new MenuContent();

            //Meal Name
            Console.WriteLine("Please enter a meal name");

            //Meal Description 
            Console.WriteLine("Please enter the meals description");

            //Meal ingriedents
            Console.WriteLine("Please enter the meals ingriedents");

            //Meal Price
            Console.WriteLine("Please enter the meals price");

            //Meal Number
            Console.WriteLine("Please enter the meals number on the menu (1-6)");
            //menu.MealMenuNumber = double.Parse(Console.ReadLine());

            //Menu number
            Console.WriteLine("Select menu number:\n" +
                "mealOne\n" +
                "mealTwo\n" +
                "mealThree\n" +
                "mealFour\n" +
                "mealFive\n" +
                "mealSix\n");
            menu.MealMenuNumber = (MealNumber)int.Parse(Console.ReadLine());
        }

        //Getting all menu options
        private void ShowAllMenu()
        {
            Console.Clear();

            List<MenuContent> listOfMenu = _menuRepo.GetContents();

            foreach(MenuContent menu in listOfMenu)
            {
                //Using helper method
                DisplayMenu(menu);

                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        //Space for specific menu options by name

        //Updating menu options
        private void UpdateMenu()
        {
            Console.Clear();

            Console.WriteLine("What is the meal in the menu you would like to update?:");
            string targetName = Console.ReadLine();

            MenuContent targetMenu = _menuRepo.GetMealByName(targetName);

            if(targetMenu == null)
            {
                Console.WriteLine("We are not able to find meal in menu");
                PressAnyKeyToContinue();
                return;
            }

            MenuContent updatedMenu = new MenuContent();

            Console.Clear();

            MenuContent menu = new MenuContent();

            //Meal Name
            Console.WriteLine($"Original Meal Name: {targetMenu.Name}\n" +
                $"Please enter a new meal name:");
            updatedMenu.Name = Console.ReadLine();

            //Meal Description 
            Console.WriteLine($"Original meal description: {targetMenu.Description}\n" +
                $"Please enter the meals new description:");
            updatedMenu.Description = Console.ReadLine();

            //Meal ingriedents
            Console.WriteLine($"Original ingriedents: {targetMenu.Ingredients}\n" +
                $"Please enter the meals new ingridients:");
            updatedMenu.Ingredients = Console.ReadLine();

            //Meal Price
            Console.WriteLine($"Original Price: {targetMenu.Price}\n" +
                $"PLease enter the meals new price");
            updatedMenu.Price = Convert.ToDouble(Console.ReadLine());

            //Meal Number
            Console.WriteLine($"Original meal number: {targetMenu.MealMenuNumber}\n" +
                $"PLease enter the meals new number (1-6)");
            updatedMenu.MealMenuNumber = (MealNumber)int.Parse(Console.ReadLine());

            //Menu number
            Console.WriteLine("Select new menu number:\n" +
                "mealOne\n" +
                "mealTwo\n" +
                "mealThree\n" +
                "mealFour\n" +
                "mealFive\n" +
                "mealSix\n");
            updatedMenu.MealMenuNumber = (MealNumber)int.Parse(Console.ReadLine());

            if(_menuRepo.UpdateExistingContent(targetMenu, updatedMenu))
            {
                Console.WriteLine("Update Successful");
            }
            else
            {
                Console.WriteLine("Update Failed!");
            }

            PressAnyKeyToContinue();
        }

        //Delete menu options
        private void RemoveContentFromMenu()
        {
            Console.Clear();

            List<MenuContent> menuList = _menuRepo.GetContents();

            int index = 1;

            foreach(MenuContent menu in menuList)
            {
                Console.WriteLine($"{index}, {menu.Name}");
                index++;
            }

            Console.WriteLine("What meal would you like to remove?");
            int targetNameId = int.Parse(Console.ReadLine());
            int targetIndex = targetNameId - 1;

            if(targetIndex >= 0 && targetIndex < menuList.Count)
            {
                MenuContent targetMenu = menuList[targetIndex];
                
                if(_menuRepo.DeleteContent(targetMenu))
                {
                    Console.WriteLine($"{targetMenu.Name}was successfully removed from menu.");
                }
                else
                {
                    Console.WriteLine("SORRY it was not successfully removed.");
                }
            }
            else
            {
                Console.WriteLine("Not a valid selection.");
            }

            PressAnyKeyToContinue();
        }

        //Helper Methods
        private void DisplayMenu(MenuContent menu)
        {
            Console.WriteLine($"Meal Name: {menu.Name}\n" +
                $"Meal Description: {menu.Description}\n" +
                $"Meal Ingriedents: {menu.Ingredients}\n" +
                $"Meal Price: {menu.Price}\n" +
                $"Meal Menu Number: {menu.MealMenuNumber}\n");
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedData()
        {
            MenuContent spagetti = new MenuContent("Spagetti", "Delicous pasta", "Homemade sauce, noodles imported from Italy", 10.99, MealNumber.mealOne);
            MenuContent Ramen = new MenuContent("Ramen", "Japanese Delicacy", "Perfect amount of noodles for you", .99, MealNumber.mealTwo);
            MenuContent Pizza = new MenuContent("Pizza", "Delicous pizza", "Homemade sauce from Italy, your choice of any toppings", 12.99, MealNumber.mealThree);
            MenuContent SpinachSoup = new MenuContent("Spinach Soup", "Thick soup ", "All homemade ingriedents", 4.29, MealNumber.mealFour);
            MenuContent Bologna = new MenuContent("Bologna", "Fresh bologna from your local Jay-C", "Your choice of thin or thick slices", 24.99, MealNumber.mealFour);
            MenuContent Ribeye = new MenuContent("Ribeye", "Grade A choice lean meat", "Comes with a salad", 54.89, MealNumber.mealSix);

            _menuRepo.AddMenuToDirectory(spagetti);
            _menuRepo.AddMenuToDirectory(Ramen);
            _menuRepo.AddMenuToDirectory(Pizza);
            _menuRepo.AddMenuToDirectory(SpinachSoup);
            _menuRepo.AddMenuToDirectory(Bologna);
            _menuRepo.AddMenuToDirectory(Ribeye);

        }
    }
}
