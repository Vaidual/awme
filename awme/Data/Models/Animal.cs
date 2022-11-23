﻿using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public string? Description { get; set; }
        public string? AvatarImage { get; set; }
        [JsonIgnore]
        public AnimalType Type { get; set; }
        public int TypeId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
