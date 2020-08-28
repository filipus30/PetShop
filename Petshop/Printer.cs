using System;
using System.Collections.Generic;
using System.Linq;
using Petshop.Core.ApplicationService;
using Petshop.Core.Entity;

namespace Petshop.ConsoleApp
{
    public class Printer
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }
        public void PrintAllPets()
        {
            Console.Write("\b");
            var allPets = _petService.GetPets();
            foreach (var pet in allPets)
            {
                Console.WriteLine($"Id = {pet.ID} Name = {pet.Name} Type = {pet.Type} BirthDate = {pet.Birthdate} Color = {pet.Color} Previous Owner = {pet.PreviousOwner} Price = {pet.Price}");
            }
            BackMenu();
        }
        public void ShowMenu()
        {
            Console.Write("\b");
            Console.WriteLine("Choose what you want to do");
            Console.WriteLine("1 - Show all Pets");
            Console.WriteLine("2 - Add new Pet");
            Console.WriteLine("3 - Delete Pet");
            Console.WriteLine("4 - Find Pets by type");
            Console.WriteLine("5 - Sort by price");
            Console.WriteLine("6 - Show five cheapest");
            Console.WriteLine("7 - Update Pet price");
            Console.WriteLine("0 - Exit");
        }

        public void AddPetMenu()
        {
            Console.Write("\b");
            Console.WriteLine("Write Pet Name");
            var name = Console.ReadLine();
            Console.WriteLine("Type");
            var type = Console.ReadLine();
            Console.WriteLine("Color");
            var color = Console.ReadLine();
            Console.WriteLine("Previous Owner");
            var prevow = Console.ReadLine();
            Console.WriteLine("Price");
            var pricee = Console.ReadLine();
            var price = Double.Parse(pricee);
            var rand = new Random();
            var birth = DateTime.Now.AddYears(rand.Next(0,5)-10);
            var sold = DateTime.Now.AddYears(rand.Next(0,5)-5);
            _petService.CreatePet(name,type,birth,sold,color,prevow,price);
            Console.WriteLine($"{type}  {name} has been added!");
            BackMenu();
        }
        public void RemovePetMenu()
        {
            Console.Write("\b");
            Console.WriteLine("Type pet's id to be removed");
            var id = Console.ReadLine();         
            _petService.DeletePet(int.Parse(id));
            Console.WriteLine("Removed!");
            BackMenu();
        }

        public void FindByTypeMenu()
        {
            Console.Write("\b");
            Console.WriteLine("Write Pet type");
            var type = Console.ReadLine();
           var pets = _petService.GetPetsByType(type);
            foreach(var pet in pets)
            {
                Console.WriteLine($"Id = {pet.ID} Name = {pet.Name} Type = {pet.Type} BirthDate = {pet.Birthdate} Color = {pet.Color} Previous Owner = {pet.PreviousOwner} Price = {pet.Price}");
            }
            BackMenu();
        }
        public void SortByPriceMenu()
        {
            Console.Write("\b");
            var allPets = _petService.GetPetsByPrice();
            foreach (var pet in allPets)
            {
                Console.WriteLine($"Id = {pet.ID} Name = {pet.Name} Type = {pet.Type} BirthDate = {pet.Birthdate} Color = {pet.Color} Previous Owner = {pet.PreviousOwner} Price = {pet.Price}");
            }
            BackMenu();

        }
        public void SortbyFiveCheapestMenu()

        {
            Console.Write("\b");
            var allPets = _petService.GetPets();
            List<Pet> SortedList = allPets.OrderBy(o => o.Price).ToList();
            foreach (var pet in SortedList.Take(5))
            {
                Console.WriteLine($"Id = {pet.ID} Name = {pet.Name} Type = {pet.Type} BirthDate = {pet.Birthdate} Color = {pet.Color} Previous Owner = {pet.PreviousOwner} Price = {pet.Price}");
            }

            BackMenu();
        }

        public void BackMenu()
        {
            Console.WriteLine("\nPress any key to back");
            Console.ReadKey();
            ShowMenu();
        }
        public void UpdatePetPriceMenu()
        {
            Console.Write("\b");
            Console.WriteLine("Type Id of Pet you want to update");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Type new price");
            var price = Double.Parse(Console.ReadLine());
            _petService.UpdatePetPrice(id, price);
            ShowMenu();
        }

    }
}
