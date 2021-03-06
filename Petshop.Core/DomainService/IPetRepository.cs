﻿using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core
{
    public interface IPetRepository
    {
        public IEnumerable<Pet> ReadPets();
        public void AddPet(Pet p);
        public void RemovePet(int id);
        public void UpdatePetPrice(int id, double price);
    }
}
