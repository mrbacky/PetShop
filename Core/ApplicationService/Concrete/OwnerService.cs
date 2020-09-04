using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Concrete {
    public class OwnerService : IOwnerService {

        private IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository) {
            _ownerRepo = ownerRepository;
        }

        public Owner Create(Owner owner) {
            return _ownerRepo.Create(owner);
        }

        public void Delete(Owner owner) {
            _ownerRepo.Delete(owner);
        }

        public List<Owner> ReadOwners() {
            return _ownerRepo.ReadOwners();
        }

        public Owner Update(Owner owner) {
            return _ownerRepo.Update(owner);
        }

        public Owner ReadById(int id) {
            return _ownerRepo.ReadById(id);
        }
    }
}
