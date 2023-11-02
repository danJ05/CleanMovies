using CleanMovie.Application.Interfaces;
using CleanMovie.Domain;
using CleanMovies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovies.Infrastructures.Repository
{
	public class MoviesRepository : IMoviesRepository
	{

		private readonly MovieDbContext _movieDbContext;
		public MoviesRepository(MovieDbContext movieDbContext)
		{
			_movieDbContext = movieDbContext;
		}

		public Movies CreateMovies(Movies movies)
		{
			 _movieDbContext.Movies.Add(movies);
			_movieDbContext.SaveChanges();
			return movies;
		}

		public List<Movies> GetAllMovies()
		{
			return _movieDbContext.Movies.ToList();
		}
	}
}
