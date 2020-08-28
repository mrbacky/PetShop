using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Static.Data {
    public class DataInitializer {

        IPetService _petService;

        public DataInitializer(IPetService petService) {
            _petService = petService;
        }

        public void InitData() {

            Pet pet1 = new Pet {
                Name = "Molly",
                /*Type = "Cat",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                PreviousOwner = "PetShopEsbjerg",
                Price = 1842.65*/
            };

            _petService.Create(pet1);

            Pet pet2 = new Pet {
                Name = "Scooby",
                /*Type = "Dog",
                Birthdate = new DateTime(2020, 6, 7),
                SoldDate = new DateTime(2020, 8, 1),
                PreviousOwner = "PetShopEsbjerg",
                Price = 1111,*/
            };

            _petService.Create(pet2);

        }


    }
}
