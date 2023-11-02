using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Interfaces
{
    public interface IMoviesService
    {
		List<Movies> GetAllMovies();
		Movies CreateMovies(Movies movies);
	}
}
