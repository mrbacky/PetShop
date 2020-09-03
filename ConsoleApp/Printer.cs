using PetShop.Core.ApplicationService.Concrete;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace PetShop.UI.ConsoleApp {
    public class Printer : IPrinter {

        IPetService _petService;
        int petId;


        public Printer(IPetService petService) {
            _petService = petService;

        }


        public void StartUI() {
            string[] menuItems = {
                "List All Pets",
                "Search by type",
                "Create Pet",
                "Delete Pet",
                "Update Pet",
                "Sort Pets by price",
                "List 5 cheapest pets",
                "Exit"
            };
            var selection = ShowMenu(menuItems);
            while (selection != 9) {
                switch (selection) {
                    case 1:
                        ListAllPets();
                        Console.WriteLine();
                        break;
                    case 2:
                        SearchPetByType();
                        Console.WriteLine();
                        break;
                    case 3:
                        var pet = BuildNewPet();
                        _petService.Create(pet);
                        Console.WriteLine();
                        break;
                    case 4:
                        DeletePet();
                        Console.WriteLine();
                        break;
                    case 5:
                        UpdatePet();
                        Console.WriteLine();
                        break;
                    case 6:
                        GetPetsSortedByPrice();
                        Console.WriteLine();
                        break;
                    case 7:
                        List5CheapestPets();
                        Console.WriteLine();
                        break;
                }
                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Bye bye!");
            Console.Write("$ ");
            Console.ReadLine();
        }

        private void List5CheapestPets() {
            List<Pet> pets = _petService.GetSortedList();
            int counter = 0;
            foreach (var item in pets) {
                if (counter < 5) {
                    Console.WriteLine($"{item.Price} {item.Name}");
                    counter++;
                }
            }
        }

        private List<Pet> GetPetsSortedByPrice() {
            List<Pet> pets = _petService.GetSortedList();
            foreach (var item in pets) {
                Console.WriteLine($"{item.Name} {item.Price}");
            }
            return pets;
        }

        private void UpdatePet() {
            petId = GetPetIdFromUser();
            var petToUpdate = _petService.FindPetById(petId);
            Console.WriteLine("Updating " + petToUpdate.Name);
            var newName = ReadUserData("$ Name: ");
            var newType = ReadUserData("$ Type: ");
            Console.Write("$ Birth date:");
            DateTime newBirthday = GetDateFromUser();
            Console.Write("$ Sold date:");
            DateTime newSoldDate = GetDateFromUser();
            var newOwner = ReadUserData("$ Owner: ");
            Console.Write("$ Price: ");
            double newPrice = GetPriceFromUser();
             
            //  asign new values to object ----- MOVE THIS 
            petToUpdate.Name = newName;
            petToUpdate.Type = newType;
            petToUpdate.Birthdate = newBirthday;
            petToUpdate.SoldDate = newSoldDate;
            petToUpdate.Owner = newOwner;
            petToUpdate.Price = newPrice;

            _petService.Update(petToUpdate);
        }

        private void DeletePet() {
            petId = GetPetIdFromUser();
            var petToDelete = _petService.FindPetById(petId);
            Console.Write("$ Deleting {0}, type YES to confirm: ", petToDelete.Name);
            if (Console.ReadLine() == "YES") {
                _petService.Delete(petToDelete);
            }
        }

        private void SearchPetByType() {
            Console.Write("$ Insert type: ");
            string type = Console.ReadLine();
            List<Pet> filteredList = _petService.FilterPetByType(type);
            foreach (var item in filteredList) {
                Console.WriteLine(item.Name, item.Type);
            }
        }

        private void ListAllPets() {
            var pets = _petService.ReadPets();
            foreach (var item in pets) {
                Console.WriteLine("id: " + item.Id + "\n"
                                + "name: " + item.Name + "\n"
                                + "type: " + item.Type + "\n"
                                + "birthday : " + item.Birthdate + "\n"
                                + "sold date : " + item.SoldDate + "\n"
                                + "owner : " + item.Owner + "\n"
                                + "price : " + item.Price + "\n"
                                );
            }
        }

        private Pet BuildNewPet() {
            Console.WriteLine("Creating new Pet ");
            var name = ReadUserData("$ name: ");
            var type = ReadUserData("$ type: ");
            Console.Write("$ birthday: ");
            DateTime birthday = GetDateFromUser();
            Console.Write("$ sold date: ");
            DateTime soldDate = GetDateFromUser();
            var owner = ReadUserData("$ owner: ");
            Console.Write("$ price: ");
            Double price = GetPriceFromUser();
            return _petService.NewPet(name, type, birthday, soldDate, owner, price);
        }

        private double GetPriceFromUser() {
            double price;
            while (!Double.TryParse(Console.ReadLine(), out price)) {
                Console.WriteLine("$ Please insert a number: ");
            }
            return price;
        }

        DateTime GetDateFromUser() {

            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday)) {
                Console.WriteLine("Please insert a correct date format -> e.g: 12/31/2020");
            }
            return birthday;
        }

        string ReadUserData(string text) {
            Console.Write(text);
            return Console.ReadLine();
        }

        int GetPetIdFromUser() {
            Console.Write("$ Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id)) {
                Console.WriteLine("$ Please insert a number: ");
            }
            return id;
        }

        /// <summary>
        /// Shows the menu.
        /// </summary>
        /// <returns>Menu Choice as int</returns>
        /// <param name="menuItems">Menu items.</param>
        int ShowMenu(string[] menuItems) {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("\nSelect What you want to do:\n");
            for (int i = 0; i < menuItems.Length; i++) {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }
            Console.WriteLine();
            Console.Write("$ ");
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 9) {
                Console.Write("$ Please select a number between 1-8: ");
            }
            Console.WriteLine();
            return selection;
        }


    }
}
