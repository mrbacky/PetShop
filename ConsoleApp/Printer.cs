using PetShop.Core.ApplicationService.Concrete;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace PetShop.UI.ConsoleApp {
    public class Printer : IPrinter {

        IPetService _petService;


        public Printer(IPetService petService) {
            _petService = petService;

        }


        public void StartUI() {
            string[] menuItems = {
                "List All Pets",
                "Create Pet",
                "Delete Pet",
                "Update Pet",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5) {
                switch (selection) {
                    case 1:
                        var pets = _petService.ReadPets();
                        foreach (var item in pets) {
                            Console.WriteLine("id: " + item.Id + "\n"
                                            + "name: " + item.Name + "\n"
                                            /*+ "type: " + item.Type + "\n"
                                            + "birthday : " + item.Birthdate + "\n"
                                            + "sold date : " + item.SoldDate + "\n"
                                            + "previous owner : " + item.PreviousOwner + "\n"
                                            + "price : " + item.Price + "\n"*/
                                            );
                        }
                        break;
                    case 2:
                        Console.WriteLine("case 2: Create Pet");
                        break;
                    case 3:
                        Console.WriteLine("case 2: Delete Pet");
                        break;
                    case 4:
                        Console.WriteLine("Type id of pet your want to update: ");
                        int petId = GetPetIdFromUser();
                        var petToUpdate = _petService.FindPetById(petId);
                        Console.WriteLine("Updating " + petToUpdate.Name);
                        var newName = ReadUserData("Firstname: ");
                        /*var newBirthday = ReadUserData("Birthday: ");
                        var newSoldDate = ReadUserData("Sold Date: ");
                        var newType = ReadUserData("Type: ");
                        var newOwner = ReadUserData("Owner: ");
                        var newPrice = ReadUserData("Price: ");*/

                        _petService.Update(new Pet() {
                            Name = newName,/*
                            Birthdate = DateTime.Parse(newBirthday),
                            Type = newType,
                            SoldDate = DateTime.Parse(newSoldDate),
                            PreviousOwner = newOwner,
                            Price = Convert.ToDouble(newPrice)*/
                        });



                        break;
                }
                selection = ShowMenu(menuItems);
                Console.WriteLine();
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        string ReadUserData(string data) {
            Console.WriteLine(data);
            return Console.ReadLine();
        }

        int GetPetIdFromUser() {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id)) {
                Console.WriteLine("Please insert a number: ");
            }
            return id;
        }

        /// <summary>
        /// Shows the menu.
        /// </summary>
        /// <returns>Menu Choice as int</returns>
        /// <param name="menuItems">Menu items.</param>
        int ShowMenu(string[] menuItems) {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++) {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5) {
                Console.WriteLine("Please select a number between 1-5");
            }
            Console.WriteLine();
            return selection;
        }


    }
}
