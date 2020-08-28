using System;
using Petshop.ConsoleApp;
using Petshop.Core;
using Petshop.Core.ApplicationService;
using Petshop.Core.ApplicationService.Implementation;
using Petshop.Core.DomainService.Implementation;
using Petshop.Infrastructure.Data;

namespace Petshop
{
    class Program
    {
        static void Main(string[] args)
        {
        
            IPetRepository petRepository = new PetRepository();
            IPetService petService = new PetService(petRepository);
            FakeDB.InitData();
            var printer = new Printer(petService);
            // printer.PrintAllPets();
            printer.ShowMenu();
            Start:
            var input = Console.ReadKey();
            switch (input.KeyChar)
            {
                case '1':
                    printer.PrintAllPets();
                    goto Start;
                case '2':
                    printer.AddPetMenu();
                    goto Start;
                case '3':
                    printer.RemovePetMenu();
                    goto Start;
                case '4':
                    printer.FindByTypeMenu();
                    goto Start;
                case '5':
                    printer.SortByPriceMenu();
                    goto Start;
                case '6':
                    printer.SortbyFiveCheapestMenu();
                    goto Start;
                case '7':
                    printer.UpdatePetPriceMenu();
                    goto Start;
                case '0':
                    return;
            }

        }
    }
}
