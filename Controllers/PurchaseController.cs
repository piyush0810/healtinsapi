using System;
using System.Threading.Tasks;
using healtinsapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using poc.Models;

namespace healtinsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController:ControllerBase
    {
        private readonly IUnitOfWork uow;

        public PurchaseController(IUnitOfWork uow)
        {
            this.uow = uow;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetPurchases()
        {
            var purchases = await uow.PurchaseRepository.GetPurchasesAsync();
            // Console.WriteLine("hui");
            return Ok(purchases);

        }


        [HttpPost("ADD")]
        public async Task<IActionResult> addpurchase(Purchase purchase)
        {

            uow.PurchaseRepository.AddPurchase(purchase);
            await uow.SaveAsync();
            return StatusCode(201);


        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeletePurchase(int id)
        {
            uow.PurchaseRepository.DeletePurchase(id);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpGet("mypolicies/{id}")]

        public  IActionResult GetMyPolicies(int id)
        {
            var policies =  uow.PurchaseRepository.GetMyPolicies(id);
            Console.WriteLine("hui");
            return Ok(policies);

        }
        
    }
}