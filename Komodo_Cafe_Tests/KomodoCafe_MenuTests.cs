using Komodo_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_Cafe_Tests
{
    [TestClass]
    public class KomodoCafe_MenuTests
    {

        //Fields to be added later
        private MenuContentRepo menuRepo;
        private MenuContentRepo Spagetti;
        //Initialize added later


        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange what i need to run test
            MenuContent menu = new MenuContent();
            MenuContentRepo menuRepo = new MenuContentRepo();

            //Act
            bool success = menuRepo.AddMenuToDirectory(menu);

            //Assert
            Assert.IsTrue(success);
        }
        //Testing Read Method
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectList()
        {
            //Arrange
            MenuContent menu = new MenuContent("Spagetti", "Delicous pasta", "Homemade sauce, noodles imported form Italy", 10.99, MealNumber.mealOne);
            //Space for menu items
            MenuContentRepo menuRepo = new MenuContentRepo();

            menuRepo.AddMenuToDirectory(menu);

            //Act
            List<MenuContent> menuList = menuRepo.GetContents();

            bool success = menuList.Contains(menu);

            //Assert
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetContentByName_ShouldReturnCorrectContent()
        {
            //Arrange
            MenuContent spagetti = new MenuContent("Spagetti", "Delicous pasta", "Homemade sauce, noodles imported from Italy", 10.99, MealNumber.mealOne);
            //Space for menu items
            MenuContent menu = new MenuContent();

            MenuContentRepo menuRepo = new MenuContentRepo();

            menuRepo.AddMenuToDirectory(spagetti);
            menuRepo.AddMenuToDirectory(menu);

            //Act
            MenuContent searchResult = menuRepo.GetMealByName("Finding Spaggeti");

            //Assert
            Assert.AreEqual(spagetti.Description, searchResult.Description);

        }
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            MenuContent menuToUpdate = menuRepo.GetMealByName("Spagetti");
            MenuContent newMenu = new MenuContent("Spagetti", "Delicous pasta", "Added alfredo sauce as an option", 11.99, MealNumber.mealOne);

            //Act
            bool updateresult = menuRepo.UpdateExistingContent(menuToUpdate, newMenu);
        }
        [TestMethod]
        public void DeleteContentByName_ShouldReturnTrue()
        {
            //Arrange
            MenuContent menuToDelete = menuRepo.GetMealByName("Spagetti");

            //Act
            bool removeResult = menuRepo.DeleteContent(menuToDelete);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
