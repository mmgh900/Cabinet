using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cabinet.Models;

namespace Cabinet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly CabinetContext _context;

        public AddressesController(CabinetContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet("most-traveled")]
        public async Task<ActionResult<IEnumerable<Address>>> GetMostTraveledAddresses()
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var addresses = await
                (from address in _context.Addresses
                 select new
                 {
                     Id = address.Id,
                     Neighborhood = address.Neighborhood.Name,
                     NighborhoodId = address.Neighborhood.Id,
                     Details = address.Details,
                     Count = _context.Commutes.Where(c => c.DestinationId == address.Id || c.OriginId == address.Id).Count()
                 })
                 .OrderByDescending(a => a.Count).ToListAsync();




            return Ok(addresses);
        }

    }
}
