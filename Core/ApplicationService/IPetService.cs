using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;



namespace PetShop.Core.Entities {
    public interface IPetService {

        List<Pet> ReadPets();

        Pet FindPetById(int id);

        Pet NewPet(string name, string type, DateTime birthday, DateTime soldDate, string owner, double price);

        Pet Create(Pet pet);

        Pet Update(Pet pet);

        void Delete(Pet pet);
        List<Pet> FilterPetByType(string type);
    }
}
