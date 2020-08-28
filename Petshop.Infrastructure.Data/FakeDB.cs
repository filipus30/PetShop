using System;
using System.Collections.Generic;
using System.Linq;
using Petshop.Core.Entity;

namespace Petshop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static List<Pet> PetsData = new List<Pet>();
        private static int Id = 1;



        public static void InitData()
        {
            PetsData.Add(new Pet
            {
                Type = "Dog",
                Name = "Bob",
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Brown",
                PreviousOwner = "None",
                Price = 100,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Cat",
                Name = "Flamingo",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-1),
                Color = "White",
                PreviousOwner = "Karen",
                Price = 1000,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Cat",
                Name = "John",
                Birthdate = DateTime.Now.AddYears(-8),
                SoldDate = DateTime.Now.AddYears(-3),
                Color = "White",
                PreviousOwner = "Barack Gagama",
                Price = 10,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Sheep",
                Name = "Lucy",
                Birthdate = DateTime.Now.AddYears(-4),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "White",
                PreviousOwner = "Alice Boop",
                Price = 400,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Dog",
                Name = "Hector",
                Birthdate = DateTime.Now.AddYears(-2),
                SoldDate = DateTime.Now.AddYears(-1),
                Color = "Brown",
                PreviousOwner = "Anastasia Potter",
                Price = 2000,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Snake",
                Name = "Thomas",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "Green",
                PreviousOwner = "Lucy Brown",
                Price = 500,
                ID = Id++

            }); ;
            PetsData.Add(new Pet
            {
                Type = "Goat",
                Name = "Nick",
                Birthdate = DateTime.Now.AddYears(-3),
                SoldDate = DateTime.Now.AddYears(-2),
                Color = "Black & White",
                PreviousOwner = "George Clinton",
                Price = 200,
                ID = Id++

            }); ;


        }
        public static IEnumerable<Pet> GetPetsData()
        {
            return PetsData;
        }
        public static void AddPet(Pet p)
        {
            p.ID = Id++;
            PetsData.Add(p);
        }
        public static void RemovePet(int id)
        {
            PetsData.RemoveAll(x => x.ID == id);
        }
        public static void UpdatePetPrice(int id,double price)
        {
            var obj = PetsData.FirstOrDefault(x => x.ID == id);
            if (obj != null) obj.Price = price;
        }

         
      

    }
}

