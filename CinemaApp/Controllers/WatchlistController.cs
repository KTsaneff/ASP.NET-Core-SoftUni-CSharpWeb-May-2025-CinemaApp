using System.Security.Claims;
using System.Threading.Tasks;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            this.watchlistService = watchlistService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = GetUserId();

            var model = await watchlistService.GetUserWatchlistAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string movieId)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = GetUserId();

            bool isInWatchlist = await watchlistService.IsMovieInWatchlistAsync(userId, Guid.Parse(movieId));

            if (!isInWatchlist)
            {
                await watchlistService.AddToWatchlistAsync(userId, movieId);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(string movieId)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = GetUserId();

            var movieGuid = Guid.Parse(movieId);

            bool isInWatchlist = watchlistService.IsMovieInWatchlistAsync(userId, movieGuid).Result;

            if (isInWatchlist)
            {
                watchlistService.RemoveFromWatchlistAsync(userId, movieId).Wait();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
