namespace Fysio.Models
{
    public class Student : IPhysioTherapist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string StudentNumber { get; set; }

        public string Date { get; set; }

        public string GetPhysioType()
        {
            return "Student";
        }
    }
}