namespace Fysio.Models
{
    public class Teacher : IPhysioTherapist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }
        
        public string Staffnumber { get; set; }
        
        public long BIG { get; set; }
        
        public string Date { get; set; }
        
        public string GetPhysioType()
        {
            return "Teacher";
        }
    }
}