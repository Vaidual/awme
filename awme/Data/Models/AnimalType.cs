namespace awme.Data.Models
{
    public class AnimalType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
