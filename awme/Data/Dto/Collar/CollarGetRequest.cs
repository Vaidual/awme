using awme.Data.Models;

namespace awme.Data.Dto.Collar
{
    public class CollarGetRequest
    {
        public string Id { get; set; }
        public bool InUse { get; set; } = false;
        public Models.Animal? Animal { get; set; }
        public Models.User? User { get; set; }
    }
}
