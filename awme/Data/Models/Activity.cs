namespace awme.Data.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool isActive { get; set; }
        public Collar Collar { get; set; }
        public string CollarId { get; set; }
    }
}
