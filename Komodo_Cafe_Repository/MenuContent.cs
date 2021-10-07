using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Repository
{
    public class MenuContent
    {
        public MenuContent() { }

        public MenuContent(string mealName, string mealDescription, string mealIngredients, double mealPrice, MealNumber numberOnMenu)
        {
            Name = mealName;
            Description = mealDescription;
            Ingredients = mealIngredients;
            Price = mealPrice;
            MealMenuNumber = numberOnMenu;

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public MealNumber MealMenuNumber { get; set; }
    }

        public enum MealNumber
        {
            mealOne = 1,
            mealTwo,
            mealThree,
            mealFour,
            mealFive,
            mealSix,
        }
}
