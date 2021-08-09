using System;
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

         [HttpGet("mycreate/{id}")]
        public IActionResult GetPoliciesCreatedById(int id)
        {
            var policies = uow.PolicyRepository.GetMyPoliciesAsync(id);

            return Ok(policies);

        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetPoliciesforIdAsync(int id)
        {
            var PolicyFromDb = await uow.PolicyRepository.FindPolicy(id);
            if(PolicyFromDb!=null){
            return Ok(PolicyFromDb);}
            return Unauthorized();

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id,Policy policy)
        {
            // Console.WriteLine(policy.policyType);
            var PolicyFromDb = await uow.PolicyRepository.FindPolicy(id);
            if(PolicyFromDb!=null){
            PolicyFromDb.policyType=policy.policyType;
            PolicyFromDb.coverName=policy.coverName;
            PolicyFromDb.coverUpto=policy.coverUpto;
            PolicyFromDb.description=policy.description;
            PolicyFromDb.email=policy.email;
            PolicyFromDb.premium=policy.premium;
            PolicyFromDb.sumInsured=policy.sumInsured;
            PolicyFromDb.termsConditions=policy.termsConditions;
            PolicyFromDb.userId=policy.userId;
            await uow.SaveAsync();
            return StatusCode(201);}
            return Unauthorized();

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