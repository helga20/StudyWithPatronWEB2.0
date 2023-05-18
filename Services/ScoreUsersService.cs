using AutoMapper;
using StudyWithPatron.Models;
using StudyWithPatron.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyWithPatron.Data;

namespace StudyWithPatron.Services
{
    public class ScoreUsersService : BaseService, IScoreUsersService
    {
        private readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ScoreUsersService(IMapper mapper, ApplicationDbContext context) : base(mapper, context) { }

        public IEnumerable<ScoreUsers> GetScoreUsers()
        {
            List<ScoreUsers> score_users = new List<ScoreUsers>();
            score_users = _mapper.Map<List<ScoreUsers>>(_context.ScoreUser.ToList());
            return score_users;
        }

        public ScoreUsers GetById(int id_user)
        {
            return _mapper.Map<ScoreUsers>(_context.ScoreUser.First(c => c.id_user == id_user));
        }

        public ScoreUsers Create(ScoreUsers score_users)
        {
            if (score_users == null)
            {
                throw new ArgumentNullException(nameof(score_users));
            }

            _context.ScoreUser.Add(_mapper.Map<ScoreUsers>(score_users));
            _context.SaveChanges();
            return score_users;
        }

        public void Update(ScoreUsers score_users)
        {
            if (score_users == null)
            {
                throw new ArgumentNullException(nameof(score_users));
            }

            _context.ScoreUser.Update(_mapper.Map<ScoreUsers>(score_users));
            _context.SaveChanges();
        }

        public void DeleteById(int id_user)
        {
            ScoreUsers score_users = GetById(id_user);
            _context.User.Remove(_mapper.Map<Users>(score_users));
            _context.SaveChanges();
        }
    }
}
