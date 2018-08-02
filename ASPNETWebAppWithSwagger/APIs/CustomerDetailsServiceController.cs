using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNETWebAppWithSwagger.Models;

namespace ASPNETWebAppWithSwagger.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsServiceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerDetailsServiceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetailsService
        [HttpGet]
        public IEnumerable<CustomerDetail> GetCustomerDetail()
        {
            return _context.CustomerDetail;
        }

        // GET: api/CustomerDetailsService/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetail = await _context.CustomerDetail.FindAsync(id);

            if (customerDetail == null)
            {
                return NotFound();
            }

            return Ok(customerDetail);
        }

        // PUT: api/CustomerDetailsService/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetail([FromRoute] int id, [FromBody] CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDetail.CustomerDetailId)
            {
                return BadRequest();
            }

            _context.Entry(customerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerDetailsService
        [HttpPost]
        public async Task<IActionResult> PostCustomerDetail([FromBody] CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomerDetail.Add(customerDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerDetail", new { id = customerDetail.CustomerDetailId }, customerDetail);
        }

        // DELETE: api/CustomerDetailsService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetail = await _context.CustomerDetail.FindAsync(id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            _context.CustomerDetail.Remove(customerDetail);
            await _context.SaveChangesAsync();

            return Ok(customerDetail);
        }

        private bool CustomerDetailExists(int id)
        {
            return _context.CustomerDetail.Any(e => e.CustomerDetailId == id);
        }
    }
}