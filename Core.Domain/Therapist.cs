﻿using System.Collections.Generic;

namespace Core.Domain
{
    public class Therapist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string AvailableDate { get; set; }
        
        public string StudentNumber { get; set; }

        public string BigNumber { get; set; }

        public int RoleId { get; set; }

        public virtual List<Appointment> Appointments { get; set; }

        public bool isStudent()
        {
            return (StudentNumber != null) ? true : false;
        }
    }
}