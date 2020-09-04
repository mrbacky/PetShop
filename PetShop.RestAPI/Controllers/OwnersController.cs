using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class OwnersController : ControllerBase {

        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService) {
            _ownerService = ownerService;
        }

        // GET: api/<OwnersController>
        [HttpGet]
        public IEnumerable<Owner> Get() {
            return _ownerService.ReadOwners();
        }

        // GET api/<OwnersController>/5
        [HttpGet("{id}")]
        public Owner Get(int id) {
            return _ownerService.ReadById(id);
        }

        // POST api/<OwnersController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<OwnersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<OwnersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
