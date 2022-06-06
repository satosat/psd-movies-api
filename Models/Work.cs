using System;
using System.Collections.Generic;

namespace MoviesAPI.Models
{
    public partial class Work
    {
        public string Nconst { get; set; } = null!;
        public string Tconst { get; set; } = null!;

        public virtual Name NconstNavigation { get; set; } = null!;
        public virtual Title TconstNavigation { get; set; } = null!;
    }
}
