using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Repository
{
    public class MenuContentRepo
    {
        //Field
        public readonly List<MenuContent> _menuDirectory = new List<MenuContent>();

        //Create
        public bool AddMenuToDirectory(MenuContent menu)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(menu);

            //Ternary
            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<MenuContent> GetContents()
        {
            return _menuDirectory;
        }
        //Get by Menu Meal Name
        public MenuContent GetMealByName(string theMealYouAreLookingFor)
        {
            foreach(MenuContent meal in _menuDirectory)
            {
                if(meal.Name.ToLower() == theMealYouAreLookingFor)
                {
                    return meal;
                }
            }
            return null;
        }

        //Update
        public bool UpdateExistingContent(MenuContent existingcontent, MenuContent newContent)
        {
            existingcontent.Name = newContent.Name;
            existingcontent.Description = newContent.Description;
            existingcontent.Ingredients = newContent.Ingredients;
            existingcontent.Price = newContent.Price;
            existingcontent.MealMenuNumber = newContent.MealMenuNumber;
            return true;
        }


        //Delete
        public bool DeleteContent(MenuContent existingContent)
        {
            bool result = _menuDirectory.Remove(existingContent);
            return result;
        }
    }
}
