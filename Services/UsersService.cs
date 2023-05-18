using AutoMapper;
using StudyWithPatron.Services.Interfaces;
using StudyWithPatron.Models;
using StudyWithPatron.Data;

namespace StudyWithPatron.Services
{
    public class UsersService : BaseService, IUsersService
    {
        private readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public UsersService(IMapper mapper, ApplicationDbContext context) :base(mapper, context) {}

        public IEnumerable<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            users = _mapper.Map<List<Users>>(_context.User.ToList());
            return users;
        }

        public Users GetById(int id)
        {
            return _mapper.Map<Users>(_context.User.First(c => c.id == id));   
        }

        public Users Create(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (_context.User.Find() ==_mapper.Map<Users>(user))
            {
                throw new ArgumentException("Such user already exists:", nameof(user));
            }

            _context.User.Add(_mapper.Map<Users>(user));
            _context.SaveChanges();
            return user;
        }

        public void Update(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.User.Update(_mapper.Map<Users>(user));
            _context.SaveChanges();
        }

        public void DeleteById(int id_user)
        {
            Users user = GetById(id_user);
            _context.User.Remove(_mapper.Map<Users>(user));
            _context.SaveChanges();
        }
    }
}