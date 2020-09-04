using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService {
    public interface IOwnerRepository {

        Owner Create(Owner owner);

        List<Owner> ReadOwners();

        Owner Update(Owner owner);

        void Delete(Owner owner);

        Owner ReadById(int id);

    }
}
