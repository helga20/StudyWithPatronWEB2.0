using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWithPatron.Models
{
    public class ScoreUsers
    {
        public int id { get; set; }

        public int id_user { get; set; }

        public int score_user { get; set; }

        public ScoreUsers(int score_user)
        {
            this.score_user = score_user;
        }
    }
}
