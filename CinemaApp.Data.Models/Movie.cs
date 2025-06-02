using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Models
{
    [Comment("Movie in the system")]
    public class Movie
    {
        [Comment("Movie Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Movie Title")]
        public string Title { get; set; } = null!;

        [Comment("Movie Genre")]
        public string Genre { get; set; } = null!;

        [Comment("Movie Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Comment("Movie Director")]
        public string Director { get; set; } = null!;

        [Comment("Movie Duration in minutes")]
        public int Duration { get; set; }

        [Comment("Movie Description")]
        public string Description { get; set; } = null!;

        [Comment("Movie Image URL")]
        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        public string? ImageUrl { get; set; }

        [Comment("Indicates if the movie is deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
