using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Therapist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public DateTime ScheduleStart { get; set; }
        
        public DateTime ScheduleEnd { get; set; }
        
        public string StudentNumber { get; set; }

        public string BigNumber { get; set; }

        public virtual List<Appointment> Appointments { get; set; }

        public bool isStudent()
        {
            return (StudentNumber != null) ? true : false;
        }
    }
}