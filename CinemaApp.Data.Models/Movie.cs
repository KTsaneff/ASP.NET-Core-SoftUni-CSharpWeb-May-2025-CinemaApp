using System.ComponentModel.DataAnnotations;
using CinemaApp.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Models
{
    [Comment("Movie in the system")]
    public class Movie
    {
        [Comment("Movie Identifier")]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Movie Title")]
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(EntityConstants.Movie.TitleMaxLength, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = null!;

        [Comment("Movie Genre")]
        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(EntityConstants.Movie.GenreMaxLength, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string Genre { get; set; } = null!;

        [Comment("Movie Release Date")]
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [Comment("Movie Director")]
        [Required(ErrorMessage = "Director is required.")]
        [StringLength(EntityConstants.Movie.DirectorMaxLength, ErrorMessage = "Director cannot exceed 100 characters.")]
        public string Director { get; set; } = null!;

        [Comment("Movie Duration in minutes")]
        [Range(1, 300, ErrorMessage = "Duration must be between 1 and 300 minutes.")]
        [Required(ErrorMessage = "Duration is required.")]
        public int Duration { get; set; }

        [Comment("Movie Description")]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(EntityConstants.Movie.DescriptionMaxLength, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = null!;

        [Comment("Movie Image URL")]
        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        public string? ImageUrl { get; set; }

        [Comment("Indicates if the movie is deleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
