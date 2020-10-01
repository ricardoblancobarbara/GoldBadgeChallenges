using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Cafe_Repository
{
    // Ingredients
    // public enum Ingredients
    // {
    //    Lettuce = 1,
    //    Tomate = 2,
    //    Bacon = 3,
    //    Cheese = 4,
    //    Onion = 5,
    //    Mushroom = 6,
    //    Pickles = 7,
    //    Burger = 8,
    //    Buns = 9,
    // }
        
    // POCO (Plain Old C# Object)
    public class Meal
    {
        // Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public double Price { get; set; }

        // Blank Constructor
        public Meal() { }

        // Overload Constructor
        public Meal(int id, string name, string description, List<string> ingredients, double price)
        {
            ID = id;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
