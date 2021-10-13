﻿using System.Collections.Generic;

namespace Fysio.Models
{
    public class Therapist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        
        public string AvailableDate { get; set; }
        
        public string StudentNumber { get; set; }

        public string BigNumber { get; set; }

        public int RoleId { get; set; }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        // public ICollection<PatientFile> PatientFiles { get; set; }
    }
}