using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService {
    public interface IPetRepositary {
        List<Pet> ReadPets();

        Pet Create(Pet petToCreate);

        Pet UpdateInDB(Pet pet);

        Pet ReadById(int id);

        void Delete(Pet pet);
        List<Pet> FilterPetByType(string type);
        List<Pet> GetPriceList();
    }
}
