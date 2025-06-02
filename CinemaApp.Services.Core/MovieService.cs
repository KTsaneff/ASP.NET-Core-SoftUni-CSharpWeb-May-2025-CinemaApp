using System.Globalization;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

using static CinemaApp.Data.Common.EntityConstants.Movie;


namespace CinemaApp.Services.Core
{
    public class MovieService : IMovieService
    {
        private readonly CinemaAppDbContext _context;
        public MovieService(CinemaAppDbContext context)
        {
            _context = context;
        }

        public async Task HardDeleteAsync(string id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SoftDeleteAsync(string id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (movie != null && !movie.IsDeleted)
            {
                movie.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditAsync(string id, MovieFormViewModel model)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (movie == null)
            {
                return;
            }

            movie.Title = model.Title;
            movie.Genre = model.Genre;
            movie.Director = model.Director;
            movie.Description = model.Description;
            movie.Duration = model.Duration;
            movie.ReleaseDate = DateTime.ParseExact(model.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture);
            movie.ImageUrl = model.ImageUrl;

            await _context.SaveChangesAsync();
        }

        public async Task<MovieFormViewModel?> GetForEditByIdAsync(string id)
        {
            return await _context.Movies
                .Where(m => m.Id.ToString() == id)
                .Select(m => new MovieFormViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    Director = m.Director,
                    Description = m.Description,
                    Duration = m.Duration,
                    ReleaseDate = m.ReleaseDate.ToString(ReleaseDateFormat),
                    ImageUrl = m.ImageUrl
                })
                .FirstOrDefaultAsync();
        }

        public async Task<MovieDetailsViewModel> GetByIdAsync(string id)
        {
            var movie = await _context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id.ToString() == id && !m.IsDeleted);

            if (movie == null)
            {
                return null;
            }

            return new MovieDetailsViewModel
            {
                Id = movie.Id.ToString(),
                Title = movie.Title,
                Genre = movie.Genre,
                Director = movie.Director,
                Description = movie.Description,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                ImageUrl = movie.ImageUrl
            };
        }

        public async Task AddAsync(MovieFormViewModel model)
        {
            var movie = new Movie
            {
                Title = model.Title,
                Genre = model.Genre,
                Director = model.Director,
                Description = model.Description,
                Duration = model.Duration,
                ReleaseDate = DateTime.ParseExact(model.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture),
                ImageUrl = model.ImageUrl
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Where(m => !m.IsDeleted)
                .AsNoTracking()
                .Select(m => new AllMoviesIndexViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    Director = m.Director,
                    ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();
        }
    }
}
