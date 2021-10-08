using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Day8Context context;
        public CustomersController (Day8Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var Query = from C1 in context.Cust
                        select C1;
           var Data = await Query.ToListAsync();
         return Ok(Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var C1 = await context.Cust.FindAsync(id);
            if(C1==null)
            {
                return NotFound();
            }
            return Ok(C1);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomer(Cust model)
        {
            context.Cust.Add(model);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer",new{id=model.Id },model);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Cust model)
        {
            context.Attach(model);
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok("model");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var C1 = await context.Cust.FindAsync(id);
            if(C1==null)
            {
                return NotFound();
            }
            context.Cust.Remove(C1);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
