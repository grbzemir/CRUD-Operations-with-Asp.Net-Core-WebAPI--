using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())

            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())

            {
                var deleteHotel = GetHotelById(id);
                hotelDbContext.Hotels.Remove(deleteHotel);
                hotelDbContext.SaveChanges();
                //Void Olduğu için geriye değer döndürmüyor.

            }
        }

        public List<Hotel> GetAllHotels()
        {
            using(var hotelDbContext = new HotelDbContext())

            {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())

            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using(var hotelDbContext = new HotelDbContext())

            {
                //var updateHotel = GetHotelById(1);
                //updateHotel.Name = "Updated Name";
                hotelDbContext.Hotels.Update(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }
    }
}
