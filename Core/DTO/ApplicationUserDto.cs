using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        //public string ConcurrencyStamp { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Avatar { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string Location { get; set; }
        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public double Rating { get; set; }
        //public string Image { get; set; }
    }
}
