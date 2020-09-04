using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Static.Data {
    public class PetRepository : IPetRepositary {

        static int id = 1;
        static List<Pet> _pets = new List<Pet>();

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

        public Pet UpdateInDB(Pet updatedPet) {
            var petFromDB = ReadById(updatedPet.Id);
            if (petFromDB != null) {
                petFromDB.Name = updatedPet.Name;
                petFromDB.Owner = updatedPet.Owner;
                petFromDB.Type = updatedPet.Type;
                petFromDB.Price = updatedPet.Price;
                petFromDB.SoldDate = updatedPet.SoldDate;
                petFromDB.Birthdate = updatedPet.Birthdate;
                return petFromDB;
            }
            return null;
        }

        public void Delete(Pet pet) {
            _pets.Remove(pet);
        }

        public List<Pet> FilterPetByType(string type) {
            return _pets.Where(x => x.Type == type).ToList();
        }

        public List<Pet> GetPriceList() {
            return _pets.OrderBy(x => x.Price).ToList();
        }


    }
}
