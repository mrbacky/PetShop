﻿using PetShop.Core.DomainService;
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

        public Pet FindPetById(int id) {
            return _petRepo.ReadById(id);
        }

        public List<Pet> ReadPets() {
            return _petRepo.ReadPets();
        }

        public Pet Update(Pet petToUpdate) {

            Pet pet = FindPetById(petToUpdate.Id);
            pet.Name = petToUpdate.Name;
            /*pet.PreviousOwner = petToUpdate.PreviousOwner;
            pet.Type = petToUpdate.Type;
            pet.Price = petToUpdate.Price;
            pet.SoldDate = petToUpdate.SoldDate;
            pet.Birthdate = petToUpdate.Birthdate;*/
            
            return _petRepo.UpdateInDB(pet);
        }
    }



}