namespace awme.Data.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimalType Type { get; set; }
        public int? Age { get; set; }
        public string Description { get; set; }
        public string AvatarImage { get; set; }
    }
}
