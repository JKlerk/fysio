namespace Core.Domain
{
    public class Image
    {
        public int Id { get; set; }
        
        public string Src { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}