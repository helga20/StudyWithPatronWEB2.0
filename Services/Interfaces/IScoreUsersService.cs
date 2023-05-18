using StudyWithPatron.Models;

namespace StudyWithPatron.Services.Interfaces
{
    public interface IScoreUsersService
    {
        IEnumerable<ScoreUsers> GetScoreUsers();

        ScoreUsers GetById(int id_user);

        ScoreUsers Create(ScoreUsers score_users);

        void Update(ScoreUsers score_users);

        void DeleteById(int id_user);

    }
}
