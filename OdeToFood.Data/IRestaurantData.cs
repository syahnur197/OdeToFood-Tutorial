using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
