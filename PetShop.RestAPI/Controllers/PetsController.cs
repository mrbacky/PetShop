using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class PetsController : ControllerBase {

        private readonly IPetService _petService;

        public PetsController(IPetService petService) {
            _petService = petService;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public IEnumerable<Pet> Get() {
            return _petService.ReadPets();
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public Pet Get(int id) {
            return _petService.FindPetById(id);
        }

        // POST api/<PetsController>
        [HttpPost]
        public void Post([FromBody] Pet pet) {
            _petService.Update(pet);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
