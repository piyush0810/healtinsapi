using System.Threading.Tasks;
using healtinsapi.Data;
using healtinsapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using poc.Models;

namespace healtinsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public PolicyController(IUnitOfWork uow)
        {
            this.uow = uow;

        }

        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await uow.PolicyRepository.GetPoliciesAsync();

            return Ok(policies);

        }

        [HttpGet("{term}")]
        public IActionResult GetPoliciesforterm(string term)
        {
            var policies = uow.PolicyRepository.GetPoliciesoftermAsync(term);

            return Ok(policies);

        }

        [HttpPost("ADD")]
        public async Task<IActionResult> AddPolicy(Policy policy)
        {

            uow.PolicyRepository.AddPolicy(policy);
            await uow.SaveAsync();
            return StatusCode(201);


        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeletePolicy(int id)
        {
            uow.PolicyRepository.DeletePolicy(id);
            await uow.SaveAsync();
            return StatusCode(201);
        }

       
        

    }
}