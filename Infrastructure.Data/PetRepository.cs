using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace PetShop.Infrastructure.Static.Data {
    public class PetRepository : IPetRepositary {

        static int id = 1;
        private List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet pet) {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public List<Pet> ReadPets() {
            return _pets;
        }
        
        public Pet ReadById(int id) {
            foreach (var pet in _pets) {
                if (pet.Id == id) {
                    return pet;
                }
            }
            return null;
        }

        public Pet UpdateInDB(Pet petToUpdate) {
            var petFromDB = this.ReadById(petToUpdate.Id);
            if (petFromDB != null) {
                petFromDB.Name = petToUpdate.Name;
                /*petFromDB.PreviousOwner = petToUpdate.PreviousOwner;
                petFromDB.Type = petToUpdate.Type;
                petFromDB.Price = petToUpdate.Price;
                petFromDB.SoldDate = petToUpdate.SoldDate;
                petFromDB.Birthdate = petToUpdate.Birthdate;*/
                return petFromDB;
            }
            return null;
        }




    }
}
