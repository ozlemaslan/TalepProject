
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Model
{
    public class User :BaseEntity
    {
        public User()
        {
            Taleps = new HashSet<Talep>();
        }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }

        [MaxLength(11)]
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Talep> Taleps { get; set; }
    }
}
