using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class paymentDetailController : ControllerBase
    {
        private readonly paymentDetailContext _context;

        public paymentDetailController(paymentDetailContext context)
        {
            _context = context;
        }

        //GET: api/paymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<projectPayment>>> GetprojectPayment()
        {
            return await _context.projectPayment.ToListAsync();
        }

        // GET: api/paymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<projectPayment>> GetprojectPayment(int id)
        {
            var projectPayment = await _context.projectPayment.FindAsync(id);

            if (projectPayment == null)
            {
                return NotFound();
            }

            return projectPayment;
        }

        // PUT: api/paymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutprojectPayment(int id, projectPayment projectPayment)
        {
            if (id != projectPayment.paymentId)
            {
                return BadRequest();
            }

            _context.Entry(projectPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectPaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.projectPayment.ToListAsync());
        }

        // POST: api/paymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<projectPayment>> PostprojectPayment(projectPayment projectPayment)
        {
            _context.projectPayment.Add(projectPayment);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetprojectPayment", new { id = projectPayment.paymentId }, projectPayment);
            return Ok(await _context.projectPayment.ToListAsync());
        }

        // DELETE: api/paymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteprojectPayment(int id)
        {
            var projectPayment = await _context.projectPayment.FindAsync(id);
            if (projectPayment == null)
            {
                return NotFound();
            }

            _context.projectPayment.Remove(projectPayment);
            await _context.SaveChangesAsync();

            return Ok(await _context.projectPayment.ToListAsync());
        }

        private bool projectPaymentExists(int id)
        {
            return _context.projectPayment.Any(e => e.paymentId == id);
        }
    }
}
