using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generater
{
    public class LoginUser
    {
        public Guid ID { get; set; }
        public Guid Org_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public DateTime birthday { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
