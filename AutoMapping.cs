using AutoMapper;
using StudyWithPatron.Models;
namespace StudyWithPatron
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Users, Users>();
            CreateMap<Users, Users>();

            CreateMap<ScoreUsers, ScoreUsers>();
            CreateMap<ScoreUsers, ScoreUsers>();
        }
    }
}