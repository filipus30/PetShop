﻿using System;
using System.Collections.Generic;
using System.Linq;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService.Implementation
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository PetRepository)
        {
            _petRepository = PetRepository;
        }


        public Pet CreatePet(string Name, string Type, DateTime BirthDate, DateTime SoldDate, string Color, string PreviousOwner, double Price)
        {
            Pet p = new Pet
            {
                Name = Name,
                Type = Type,
                Birthdate = BirthDate,
                SoldDate = SoldDate,
                Color = Color,
                PreviousOwner = PreviousOwner,
                Price = Price
            };
            _petRepository.AddPet(p);
            return p;
         }

        public void DeletePet(int id)
        {
            _petRepository.RemovePet(id);
        }

        public List<Pet> GetPets()
        {
            return (List<Pet>)_petRepository.ReadPets();
        }

        public List<Pet> GetPetsByPrice()
        {
            List<Pet> SortedList = GetPets().OrderBy(o => o.Price).ToList();
            return SortedList;
        }

        public IEnumerable<Pet> GetPetsByType(string type)
        {
            List<Pet> filtered = new List<Pet>();
            filtered = GetPets().FindAll(x => x.Type.ToLower().Equals(type.ToLower()));
            return filtered;
        }

        public void UpdatePetPrice(int id, double price)
        {
            _petRepository.UpdatePetPrice(id, price);
        }
    }
}
