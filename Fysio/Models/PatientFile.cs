using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class PatientFile
    {
        public int Id { get; set; }
        
        public int PatientId { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public string DiagnoseCode { get; set; }

        // Student of teacher
        public IPhysioTherapist PatientType { get; set; }
        
        public int InterviewerId { get; set; }
        
        public int InterviewSupervisorId { get; set; }

        public int PractitionerId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        public string UnRegisterDate { get; set; }

        public string Notes { get; set; }

        public string TreatmentPlan { get; set; }

        public LinkedList<Treatment> Treatments { get; set; }
    }
}