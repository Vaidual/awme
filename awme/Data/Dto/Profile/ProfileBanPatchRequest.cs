namespace awme.Data.Dto.Profile
{
    public class ProfileBanPatchRequest
    {
        public bool IsBanned { get; set; }
        public DateTime? BanEnd { get; set; }
    }
}
