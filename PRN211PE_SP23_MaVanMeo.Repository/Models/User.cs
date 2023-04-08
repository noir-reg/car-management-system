using System;
using System.Collections.Generic;

namespace PRN211PE_SP23_MaVanMeo.Repository.Models
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserName { get; set; }
        public int? UserRole { get; set; }
    }
}
