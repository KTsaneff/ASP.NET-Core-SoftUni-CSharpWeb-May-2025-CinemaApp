using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models
{
    public class UserMovie
    {
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;
    }
}
