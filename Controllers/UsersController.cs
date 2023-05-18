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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace StudyWithPatron.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;
        //protected readonly var user_id;

        public UsersController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            //user_id = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var curr_usr = _context.Users.FirstOrDefault(m => m.UserName == User.Identity.Name);

        }

        [HttpGet]
        public ActionResult<List<Users>> Get()
        {
            return _context.User.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<Users> Create(Users user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Users user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}




