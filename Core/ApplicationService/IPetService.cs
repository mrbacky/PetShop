using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;



namespace PetShop.Core.Entities {
    public interface IPetService {

        List<Pet> ReadPets();

        Pet FindPetById(int id);

        Pet Create(Pet pet);

        Pet Update(Pet pet);

    }
}
