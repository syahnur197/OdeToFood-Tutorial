using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scotts Pizza", Location = "Somewhere not in Brunei", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 2, Name = "Margeherita", Location = "Indonesia", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Foo bar", Location = "Malaysia", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 4, Name = "Lorem ipsum", Location = "Vietnam", Cuisine = CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}
