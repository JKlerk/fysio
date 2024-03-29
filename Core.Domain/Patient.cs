using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Patient
    {
        public int Id { get; set; }

        public string PatientNumber { get; set; }

        public string StaffNumber { get; set; }

        public string BigNumber { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public virtual Image Image { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public virtual PatientFile PatientFile { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
        
        public int CalculateAge()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - this.Birthdate.Year;
            if (now.Month < this.Birthdate.Month || (now.Month == this.Birthdate.Month && now.Day < this.Birthdate.Day))
                age--;
            return age;
        }
    }
}