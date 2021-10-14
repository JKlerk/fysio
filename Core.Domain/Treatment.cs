using System;

namespace Core.Domain
{
    public class Treatment
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        // public IPhysioTherapist Practitioner { get; set; }
        
        public DateTime Date { get; set; }
    }

}