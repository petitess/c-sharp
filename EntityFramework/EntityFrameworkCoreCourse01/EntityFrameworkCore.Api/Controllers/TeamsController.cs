using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using EntityFrameworkCore.Api.Models;

namespace EntityFrameworkCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly FotballLeagueDbContext _context;

        public TeamsController(FotballLeagueDbContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            //return await _context.Teams.ToListAsync();
            var teams = await _context.Teams.Select(x=> new TeamDto
            {
                Name = x.Name,
                Id = x.Id,
                CoachName = x.Coach.Name
            }).ToListAsync();

            return Ok(teams);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            if (_context.Teams == null)
            {
                return NotFound();            
            }
            var team = await _context.Teams
                .Include(x=>x.Coach)
                .Include(x=>x.League)
                .FirstOrDefaultAsync(x=>x.Id == id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = _context.Teams;
            if (team == null)
            {
                return NotFound();
            }

            await _context.Teams.Where(x=>x.Id == id).ExecuteDeleteAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
