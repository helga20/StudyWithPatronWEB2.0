using AutoMapper;
using StudyWithPatron.Data;

namespace StudyWithPatron
{
    public class BaseService
    { 
        protected IMapper _mapper;
        protected ApplicationDbContext _context;
        public BaseService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
