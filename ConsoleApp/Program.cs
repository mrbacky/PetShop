using Microsoft.Extensions.DependencyInjection;
using PetShop.Infrastructure.Static.Data;
using PetShop.Core.ApplicationService.Concrete;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.UI.ConsoleApp;
using System;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepositary, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var petService = serviceProvider.GetRequiredService<IPetService>();
            var dataInitializer = new DataInitializer(petService);

            dataInitializer.InitData();

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
