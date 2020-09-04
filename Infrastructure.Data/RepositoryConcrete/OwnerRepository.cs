using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Static.Data.RepositoryConcrete {
    public class OwnerRepository : IOwnerRepository {

        static int id = 1;
        List<Owner> _owners = new List<Owner>();

        public Owner Create(Owner owner) {
            owner.Id = id++;
            _owners.Add(owner);
            return owner;
        }

        public void Delete(Owner owner) {
            throw new NotImplementedException();
        }

        public List<Owner> ReadOwners() {
            return _owners;
        }

        public Owner Update(Owner owner) {
            throw new NotImplementedException();
        }

        public Owner ReadById(int id) {
            throw new NotImplementedException();
        }
    }
}
