using CleanMovie.Application.Interfaces;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovies.WebAPi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMoviesService _moviesService;

		public MoviesController(IMoviesService moviesService)
		{
			_moviesService = moviesService;
		}

		[HttpGet]
		public ActionResult<List<Movies>> getAllMovie()
		{
			var movieFromService = 	_moviesService.GetAllMovies();
			return Ok(movieFromService);
		}

		[HttpPost]
		public ActionResult<Movies> CreateMovie( Movies movie )
		{
			_moviesService.CreateMovies(movie);
			return Ok(movie);
		}
	}
}
