using System.ComponentModel.DataAnnotations;

namespace FysioAPI
{
    public class TreatmentType
    {
        public int Id { get; set; }
        
        [Required]
        public string TreatmentCode { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string ExplanationRequired { get; set; }
    }
}