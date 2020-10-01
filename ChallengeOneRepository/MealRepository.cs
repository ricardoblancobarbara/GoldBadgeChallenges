using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Cafe_Repository
{
    public class MealRepository
    {
        private List<Meal> _listOfMeal = new List<Meal>();

        // CRUD
        // Create Method
        public bool AddMealToList(Meal meal)
        {
            int initialCount = _listOfMeal.Count;
            _listOfMeal.Add(meal);

            if (initialCount < _listOfMeal.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Read Method
        public List<Meal> GetMealList()
        {
            return _listOfMeal;
        }

        // Update Method
        public bool UpdateMealByID(int originalMealID, Meal newMeal)
        {
            // Find original meal
            Meal oldMeal = GetMealByID(originalMealID);

            // Update the original meal
            if (oldMeal != null)
            {
                // oldMeal.ID = newMeal.ID; 
                oldMeal.Name = newMeal.Name;
                oldMeal.Description = newMeal.Description;
                oldMeal.Ingredients = newMeal.Ingredients;
                oldMeal.Price = newMeal.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete Method
        public bool DeleteMealByID(int mealID)
        {
            Meal meal = GetMealByID(mealID);
            if (meal == null)
            {
                return false;
            }

            int initialCount = _listOfMeal.Count;
            _listOfMeal.Remove(meal);

            if (initialCount > _listOfMeal.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        public Meal GetMealByID(int mealID)
        {
            foreach(Meal meal in _listOfMeal)
            {
                if(meal.ID == mealID)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
