namespace MoviesAPI.Models
{
    public partial class Name
    {
        public string Nconst { get; set; } = null!;
        public string PrimaryName { get; set; } = null!;
        public string BirthYear { get; set; } = null!;
        public string? DeathYear { get; set; }
    }
}
