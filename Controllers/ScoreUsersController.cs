using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudyWithPatron.Models;
using StudyWithPatron;
using StudyWithPatron.Data;
using Microsoft.AspNetCore.Authorization;

namespace StudyWithPatron.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ScoreUsersController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;

        public ScoreUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ScoreUsers>> Get()
        {
            return _context.ScoreUser.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ScoreUsers> Get(int id)
        {
            var score_user = _context.ScoreUser.Find(id);
            if (score_user == null)
            {
                return NotFound();
            }
            return score_user;
        }

        //[HttpPost]
        //public async Task<ActionResult<ScoreUsers>> Create(ScoreUsers scoreUser)
        //{
        //    _context.ScoreUser.Add(scoreUser);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(Get), new { id = scoreUser.id }, scoreUser);
        //}
     
        [HttpPost]
        public async Task<ActionResult<ScoreUsers>> Create(ScoreUsers scoreUser, int score)
        {
            _context.ScoreUser.Add(new ScoreUsers(scoreUser.score_user));
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = scoreUser.id }, scoreUser);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ScoreUsers score_user)
        {
            if (id != score_user.id)
            {
                return BadRequest();
            }

            _context.Entry(score_user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var score_user = _context.ScoreUser.Find(id);
            if (score_user == null)
            {
                return NotFound();
            }

            _context.ScoreUser.Remove(score_user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}


