using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		public ViewResult Index()
		{
			var movies = GetMovies();

			return View(movies);
		}

		private IEnumerable<Movie> GetMovies()
		{
			return new List<Movie>
			{
				new Movie { Id = 1, Name = "Shrek" },
				new Movie { Id = 2, Name = "Wall-e" }
			};
		}

		// GET: Movies/Random
		public ActionResult Random()
		{
			//Creating instance of our Moview model we created
			var movie = new Movie() { Name = "Shrek!" };

			var customers = new List<Customer>
			{
				new Customer {Name = "Customer 1"},
				new Customer {Name = "Customer 2"}
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			//To render our view
			return View(viewModel);
		}

		public ActionResult Edit(int id)
		{
			return Content("id = " + id);
		}
	}
}