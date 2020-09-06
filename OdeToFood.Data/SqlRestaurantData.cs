using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);

            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restraunt = GetById(id);

            if (restraunt != null)
            {
                db.Remove(restraunt);
            }

            return restraunt;
        }

        public Restaurant GetById(int id)
        {
            var restaurant = db.Restaurants.Find(id);

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants 
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name) 
                        orderby r.Name 
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = db.Restaurants.Attach(updatedRestaurant);
            restaurant.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
