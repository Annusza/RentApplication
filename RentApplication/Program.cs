using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using RentApplication.Model;

namespace RentApplication
{
    class Program
    {
        private IEnumerable<Flat> _flats = InitFlats();

        static void Main(string[] args)
        {
        }

        public void AddFlat(string city, string street, string zipCode,
            decimal price)
        {
            var listOfFlats = _flats.ToList();
            listOfFlats.Add(new Flat()
            {
                City = city,
                Street = street,
                ZipCode = zipCode,
                Price = price
            });

            _flats = listOfFlats;
        }


        public void RemoveFlat(Flat flat)
        {
            var listOfFlats = _flats.ToList();
            listOfFlats.Remove(flat);
            _flats = listOfFlats;
        }

        public IEnumerable<Flat> FindFlatsByCity(string city)
        {
          return _flats.ToList().FindAll(x => x.City == city);
        }
        
        private static IEnumerable<Flat> InitFlats()
        {
            return new List<Flat>
            {
                new Flat()
                {
                    Price = 1000,
                    Floor = 1,
                    City = "Gdańsk",
                    Street = "Brzegi 55",
                    ZipCode = "80-222",
                    District = "Orunia dolna",
                    SquareMeters = 200,
                    NumberOfRooms = 5
                },
                new Flat()
                {
                    City = "Gdynia",
                    Floor = 6,
                    Price = 1799,
                    Street = "Wielkopolska 1",
                    ZipCode = "81-123",
                    District = "Mały Kack",
                    IsElevator = true,
                    SquareMeters = 60,
                    NumberOfRooms = 2
                }
            };
        }
    }
}