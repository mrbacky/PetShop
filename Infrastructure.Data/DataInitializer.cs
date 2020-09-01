using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Static.Data {
    public class DataInitializer {
        readonly IPetService _petService;

        public DataInitializer(IPetService petService) {
            _petService = petService;
        }

        public void InitData() {

            Pet pet1 = new Pet {
                Name = "Molly",
                Type = "Cat",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                Owner = "PetShopEsbjerg",
                Price = 1842.65
            };
            _petService.Create(pet1);

            Pet pet2 = new Pet {
                Name = "Scooby",
                Type = "Dog",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                Owner = "PetShopEsbjerg",
                Price = 1111,
            };
            _petService.Create(pet2);

            Pet pet3 = new Pet {
                Name = "Mikey",
                Type = "Dog",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                Owner = "PetShopEsbjerg",
                Price = 333,
            };
            _petService.Create(pet3);

            Pet pet4 = new Pet {
                Name = "Travis",
                Type = "Cat",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                Owner = "PetShopEsbjerg",
                Price = 32541,
            };
            _petService.Create(pet4);

            Pet pet5 = new Pet {
                Name = "Vincent",
                Type = "Dog",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                Owner = "John Wick",
                Price = 9711254,
            };
            _petService.Create(pet5);

            Pet pet6 = new Pet {
                Name = "Stewart",
                Type = "Mouse",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                Owner = "Carl Johnson",
                Price = 7471,
            };
            _petService.Create(pet6);
        }


    }
}
