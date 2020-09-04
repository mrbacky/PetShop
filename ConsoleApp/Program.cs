using Microsoft.Extensions.DependencyInjection;
using PetShop.Infrastructure.Static.Data;
using PetShop.Core.ApplicationService.Concrete;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.UI.ConsoleApp;
using System;
using PetShop.Infrastructure.Static.Data.RepositoryConcrete;
using PetShop.Core.ApplicationService;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepositary, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();

            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var petService = serviceProvider.GetRequiredService<IPetService>();
            var ownerService = serviceProvider.GetRequiredService<IOwnerService>();
            var dataInitializer = new DataInitializer(petService, ownerService);

            dataInitializer.initPets();

            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();

            Console.ReadLine();
            /*////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();*/
        }
    }
}
