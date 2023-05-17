using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWithPatron.Models
{
    public class Users
    {
        public int id { get; set; }

        public string login { get; set; }

        public Users(string login)
        {
            this.login = login;
        }
    }
}
