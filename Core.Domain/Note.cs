using System;

namespace Core.Domain
{
    public class Note
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public string Placer { get; set; }

        public bool VisibleForPatient { get; set; }
        
        public int PatientFileId { get; set; }
        public virtual PatientFile PatientFile { get; set; }
    }
}