﻿using System.Text.Json.Serialization;

namespace awme.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserProfileId { get; set; }
        [JsonIgnore]
        public Profile UserProfile { get; set; }
    }
}