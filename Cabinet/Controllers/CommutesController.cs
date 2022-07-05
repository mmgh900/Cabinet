using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cabinet.Models;
using Cabinet.Classes;
using Cabinet.Utills;
using Microsoft.AspNetCore.Authorization;

namespace Cabinet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommutesController : ControllerBase
    {
        private readonly CabinetContext _context;

        public CommutesController(CabinetContext context)
        {
            _context = context;
        }


        // GET: Commutes
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<CommuteOutputDTO>>> GetCommutes()
        {
            if (_context.Commutes == null)
            {
                return NotFound();
            }
            return await _context.Commutes.Select(c => new CommuteOutputDTO
            {
                Id = c.Id,
                RequestTime = c.DateRequested.ToString(),
                Origin = c.Origin.Neighborhood.Name + ", " + c.Origin.Details,
                Destination = c.Destination.Neighborhood.Name + ", " + c.Destination.Details,
                Price = c.Price,
                CommuterName = c.Commuter.FirstName + " " + c.Commuter.LastName,
                CommuterEmail = c.Commuter.Email,
                DriverEmail = c.Driver.Email,
                DriverName = c.Driver.FirstName + " " + c.Driver.LastName,
                DriverScore = c.Driver.DriverCommutes.Average(c => c.Score) / 10,
                Status = c.Status.ToStatusString(),
                Score = c.Score
            }).OrderByDescending(c => c.RequestTime).ToListAsync();
        }



        // GET: Commutes/pendings
        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<CommuteOutputDTO>>> GetCommutesHistory()
        {
            if (_context.Commutes == null)
            {
                return NotFound();
            }

            var userId = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
            if (userId == null)
            {
                return Problem("Couldn't get the user id");
            }

            var pendings = await _context.Commutes
                .Where(c =>
                    (c.Status == CommuteStatus.Canceled || c.Status == CommuteStatus.Completed)
                    &&
                    (c.DriverId == userId || c.CommuterId == userId)
                )
                .Select(c => new CommuteOutputDTO
                {
                    Id = c.Id,
                    RequestTime = c.DateRequested.ToString(),
                    Origin = c.Origin.Neighborhood.Name + ", " + c.Origin.Details,
                    Destination = c.Destination.Neighborhood.Name + ", " + c.Destination.Details,
                    Price = c.Price,
                    CommuterName = c.Commuter.FirstName + " " + c.Commuter.LastName,
                    DriverName = c.Driver.FirstName + " " + c.Driver.LastName,
                    DriverScore = c.Driver.DriverCommutes.Average(c => c.Score) / 10,
                    Status = c.Status.ToStatusString(),
                    Score = c.Score,
                    DriverEmail = c.Driver.Email,
                    CommuterEmail = c.Commuter.Email
                }).OrderByDescending(c => c.RequestTime).ToListAsync();

            return Ok(pendings);

        }


        // GET: Commutes/pendings
        [HttpGet("pendings")]
        [Authorize(Roles = "Driver")]
        public async Task<ActionResult<IEnumerable<CommuteOutputDTO>>> GetPendingCommutes()
        {
            if (_context.Commutes == null)
            {
                return NotFound();
            }

            var pendings = await _context.Commutes.Where(c => c.Status == CommuteStatus.WaitingForDriver).Select(c => new CommuteOutputDTO
            {
                Id = c.Id,
                RequestTime = c.DateRequested.ToString(),
                Origin = c.Origin.Neighborhood.Name + ", " + c.Origin.Details,
                Destination = c.Destination.Neighborhood.Name + ", " + c.Destination.Details,
                Price = c.Price,
                CommuterName = c.Commuter.FirstName + " " + c.Commuter.LastName,
                Status = c.Status.ToStatusString(),
                Score = c.Score,
                CommuterEmail = c.Commuter.Email,


            }).OrderByDescending(c => c.RequestTime).ToListAsync();

            return Ok(pendings);

        }

        // GET: Commutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommuteOutputDTO>> GetCommute(long id)
        {
            if (_context.Commutes == null)
            {
                return NotFound();
            }
            var commute = await _context.Commutes.Where(c => c.Id == id).Select(c =>
            new CommuteOutputDTO
            {
                Id = c.Id,
                RequestTime = c.DateRequested.ToString(),
                Origin = c.Origin.Neighborhood.Name + ", " + c.Origin.Details,
                Destination = c.Destination.Neighborhood.Name + ", " + c.Destination.Details,
                Price = c.Price,
                CommuterName = c.Commuter.FirstName + " " + c.Commuter.LastName,
                DriverName = c.Driver.FirstName + " " + c.Driver.LastName,
                Status = c.Status.ToStatusString(),
                Score = c.Score,
                DriverEmail = c.Driver.Email,
                DriverScore = c.Driver.DriverCommutes.Average(c => c.Score) / 10,
                CommuterEmail = c.Commuter.Email,



            }).FirstOrDefaultAsync();

            if (commute == null)
            {
                return NotFound();
            }

            return commute;
        }


        // GET: Commutes/5
        [HttpGet("current")]
        public async Task<ActionResult<CommuteOutputDTO>> GetCurrentCommute()
        {
            if (_context.Commutes == null)
            {
                return NotFound();
            }
            var user = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return Problem("Couldn't get the user id");
            }
            var commute = await _context.Commutes
                .Where(c =>
                (c.CommuterId == user.Id || c.DriverId == user.Id)
                &&
                (
                    c.Status == CommuteStatus.WaitingForDriver ||
                    c.Status == CommuteStatus.InProgress ||
                    (User.IsInRole("Commuter") && c.Score == null && c.Status == CommuteStatus.Completed))
                )
                .Select(c =>
                    new CommuteOutputDTO
                    {
                        Id = c.Id,
                        RequestTime = c.DateRequested.ToString(),
                        Origin = c.Origin.Neighborhood.Name + ", " + c.Origin.Details,
                        Destination = c.Destination.Neighborhood.Name + ", " + c.Destination.Details,
                        Price = c.Price,
                        CommuterName = c.Commuter.FirstName + " " + c.Commuter.LastName,
                        DriverName = c.Driver.FirstName + " " + c.Driver.LastName,
                        Status = c.Status.ToStatusString(),
                        Score = c.Score,
                        CommuterEmail = c.Commuter.Email,
                        DriverEmail = c.Driver.Email,
                        DriverScore = c.Driver.DriverCommutes.Average(c => c.Score) / 10,

                    })
                .FirstOrDefaultAsync();

            if (commute == null)
            {
                return Ok();
            }

            return Ok(commute);
        }
        // PATCH: Commutes/5
        [HttpPatch("{id}/accept")]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> Accept(long id)
        {
            try
            {
                var commute = _context.Commutes.Find(id);
                if (commute == null)
                {
                    return BadRequest("Commute not found");
                }

                var user = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                
                
                if (user == null)
                {
                    return Problem("Couldn't get the user id");
                }

                if (user.IsBlocked)
                {
                    return Problem("You are blocked");
                }
                var userId = user.Id;
                var currentCommute = await _context.Commutes.Where(c => (c.DriverId == userId) && (c.Status == CommuteStatus.WaitingForDriver || c.Status == CommuteStatus.InProgress)).FirstOrDefaultAsync();
                if (currentCommute != null)
                {
                    return BadRequest("You already have a commute in progress");
                }
                if (commute.DriverId != null)
                {
                    return BadRequest("Commute already accepted");
                }

                commute.DriverId = userId;
                commute.Status = CommuteStatus.InProgress;



                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommuteExists(id))
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

        public class PriceChangeRequest
        {
            public float price { get; set; }
        }
        // PATCH: Commutes/5
        [HttpPatch("{id}/change-price")]
        [Authorize(Roles = "Commuter")]

        public async Task<IActionResult> ChangePrice(long id, [FromBody] PriceChangeRequest body)
        {
            try
            {
                var commute = await _context.Commutes.Include(c => c.Commuter).Where(c => c.Id == id).FirstOrDefaultAsync();

                if (commute == null)
                {
                    return BadRequest("Commute not found");
                }

                if (body.price <= 0)
                {
                    return BadRequest("Price can't be negative or zero");
                }
                if (commute.Status != CommuteStatus.WaitingForDriver)
                {
                    return BadRequest("Commute is not in waiting for driver");
                }

                var userId = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
                if (userId == null)
                {
                    return Problem("Couldn't get the user id");
                }

                if (commute.Commuter.Id != userId)
                {
                    return BadRequest("You are not the commuter");
                }

                commute.Price = body.price;
                commute.DateRequested = DateTime.Now;


                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommuteExists(id))
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

        // PATCH: Commutes/5
        [HttpPatch("{id}/cancel")]
        [Authorize(Roles = "Commuter")]
        public async Task<IActionResult> CancelCommute(long id)
        {
            try
            {
                var commute = await _context.Commutes.Include(c => c.Commuter).Where(c => c.Id == id).FirstOrDefaultAsync();
                if (commute == null)
                {
                    return BadRequest("Commute not found");
                }


                var userId = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
                if (userId == null)
                {
                    return Problem("Couldn't get the user id");
                }

                if (commute.Commuter.Id != userId)
                {
                    return BadRequest("You are not the commuter");
                }
                commute.Status = CommuteStatus.Canceled;
                commute.DateEnded = DateTime.Now;


                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommuteExists(id))
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

        // PATCH: Commutes/5
        [HttpPatch("{id}/end")]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> EndCommute(long id)
        {

            try
            {
                var commute = await _context.Commutes.Include(c => c.Driver).Where(c => c.Id == id).FirstOrDefaultAsync();

                if (commute == null)
                {
                    return BadRequest("Commute not found");
                }

                var user = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();


                if (user == null)
                {
                    return Problem("Couldn't get the user id");
                }

                if (user.IsBlocked)
                {
                    return Forbid("You are blocked");
                }
                var userId = user.Id;

                if (commute.Driver.Id != userId)
                {
                    return BadRequest("You are not the driver of this commutes");
                }
                if (commute.Status != CommuteStatus.InProgress)
                {
                    return BadRequest("Commute is not in progress");
                }
                commute.Status = CommuteStatus.Completed;
                commute.DateEnded = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommuteExists(id))
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


        public class RateCommuteRequest
        {
            public int score { get; set; }
        }
        // PATCH: Commutes/5
        [HttpPatch("{id}/rate")]
        [Authorize(Roles = "Commuter")]
        public async Task<IActionResult> RateCommute(long id, [FromBody] RateCommuteRequest body)
        {
            try
            {
                var commute = await _context.Commutes.Include(c => c.Commuter).Where(c => c.Id == id).FirstOrDefaultAsync();

                if (commute == null)
                {
                    return BadRequest("Commute not found");
                }

                var userId = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
                if (userId == null)
                {
                    return Problem("Couldn't get the user id");
                }

                if (commute.Commuter.Id != userId)
                {
                    return BadRequest("You are not the commuter");
                }
                if (commute.Status != CommuteStatus.Completed)
                {
                    return BadRequest("Commute is not completed");
                }
                if (body.score > 100 || body.score < 0)
                {
                    return BadRequest("Score must between 0 and 100");
                }
                commute.Score = body.score;


                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommuteExists(id))
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

        // PUT: Commutes/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCommute(long id, Commute commute)
        {
            if (id != commute.Id)
            {
                return BadRequest();
            }

            _context.Entry(commute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommuteExists(id))
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

        // POST: Commutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Commuter")]
        public async Task<ActionResult<Commute>> PostCommute([FromBody] CommuteAddDTO commute)
        {
            if (_context.Commutes == null)
            {
                return Problem("Entity set 'CabinetContext.Commutes'  is null.");
            }
            var distinationId = commute.DestinationId;
            var originId = commute.OriginId;

            if (distinationId == null)
            {
                if (commute.DestinationDetails == null || commute.DestinationNeighborhoodId == null)
                {
                    return BadRequest("Destination is not selected. Either select a stored address or craete one by entering neighbirhood and details.");
                }
                else
                {
                    var newAddress = new Address
                    {
                        Details = commute.DestinationDetails,
                        NeighborhoodId = (long)commute.DestinationNeighborhoodId
                    };
                    _context.Addresses.Add(newAddress);
                    await _context.SaveChangesAsync();
                    distinationId = newAddress.Id;
                }
            }
            if (originId == null)
            {
                if (commute.OriginDetails == null || commute.OriginNeighborhoodId == null)
                {
                    return BadRequest("Either select a stored address or craete one by entering neighbirhood and details.");
                }
                else
                {
                    var newAddress = new Address
                    {
                        Details = commute.OriginDetails,
                        NeighborhoodId = (long)commute.OriginNeighborhoodId
                    };
                    _context.Addresses.Add(newAddress);
                    await _context.SaveChangesAsync();
                    originId = newAddress.Id;
                }
            }
            var userId = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
            if (userId == null)
            {
                return Problem("Couldn't get the user id");
            }
            var currentCommute = await _context.Commutes.Where(c => (c.CommuterId == userId) && (c.Status == CommuteStatus.WaitingForDriver || c.Status == CommuteStatus.InProgress)).FirstOrDefaultAsync();
            if (currentCommute != null)
            {
                return BadRequest("You already have a commute in progress");
            }
            var newCommute = new Commute
            {
                DestinationId = (long)distinationId,
                OriginId = (long)originId,
                CommuterId = userId,
                Price = commute.Price,
            };
            _context.Commutes.Add(newCommute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommute", new { id = newCommute.Id }, new { id = newCommute.Id, price = newCommute.Price });
        }

        // DELETE: Commutes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCommute(long id)
        {
            if (_context.Commutes == null)
            {
                return NotFound();
            }
            var commute = await _context.Commutes.FindAsync(id);
            if (commute == null)
            {
                return NotFound();
            }

            _context.Commutes.Remove(commute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommuteExists(long id)
        {
            return (_context.Commutes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
