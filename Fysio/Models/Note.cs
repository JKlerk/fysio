using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public string Placer { get; set; }
        
        [Required]
        public bool VisibleForPatient { get; set; }
        
        public int PatientFileId { get; set; }
        public virtual PatientFile PatientFile { get; set; }
    }
}