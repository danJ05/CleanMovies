using CleanMovie.Application.Interfaces;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Services
{
	public class MoviesServices : IMoviesService
	{
		private readonly IMoviesRepository _movieRepository;

		public MoviesServices( IMoviesRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public Movies CreateMovies(Movies movies)
		{
			_movieRepository.CreateMovies(movies);
			return movies;
		}

		public List<Movies> GetAllMovies()
		{
			return _movieRepository.GetAllMovies();
		}
	}
}
