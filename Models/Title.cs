using System;
using System.Collections.Generic;

namespace MoviesAPI.Models
{
    public partial class Title
    {
        public string Tconst { get; set; } = null!;
        public string PrimaryTitle { get; set; } = null!;
        public string OriginalTitle { get; set; } = null!;
        public string StartYear { get; set; } = null!;
    }
}
