using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Concrete {

    public class PetService : IPetService {
        private readonly IPetRepositary _petRepo;

        public PetService(IPetRepositary petRepository) {
            _petRepo = petRepository;
        }

        public Pet Create(Pet pet) {
            return _petRepo.Create(pet);
        }

        public void Delete(Pet pet) {
            _petRepo.Delete(pet);
        }

        public List<Pet> FilterPetByType(string type) {
            return _petRepo.FilterPetByType(type);
        }

        public Pet FindPetById(int id) {
            return _petRepo.ReadById(id);
        }



        public List<Pet> GetSortedList() {
            return _petRepo.GetPriceList();
        }

        public Pet NewPet(string name, string type, DateTime birthday, DateTime soldDate, string owner, double price) {
            var newPet = new Pet() {
                Name = name,
                Type = type,
                Birthdate = birthday,
                SoldDate = soldDate,
                Owner = owner,
                Price = price
            };
            return newPet;
        }

        public List<Pet> ReadPets() {
            return _petRepo.ReadPets();
        }

        public Pet Update(Pet updatedPet) {
            return _petRepo.UpdateInDB(updatedPet);
        }
    }



}
