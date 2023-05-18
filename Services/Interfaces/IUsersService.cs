using StudyWithPatron.Models;

namespace StudyWithPatron.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<Users> GetUsers();

        Users GetById(int id);

        Users Create(Users user);

        void Update(Users user);

        void DeleteById(int id_user);
    }
}

