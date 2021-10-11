using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        
        public string Phonenumber { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Postalcode { get; set; }
    }
}