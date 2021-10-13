using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class Treatment
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public IPhysioTherapist Practitioner { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

}