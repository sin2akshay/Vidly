using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		//We need a DbContext to access the Database
		private ApplicationDbContext _context;

		//We need to initialize the DbContext in Contructor
		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		//DbContext is a Disposable Object and we need to dispose it properly
		//Proper way is to override Dipose method of the base Controller class
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult Index()
		{
			var movies = _context.Movies.Include(m => m.Genre).ToList();

			return View(movies);
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);

		}

		//private IEnumerable<Movie> GetMovies()
		//{
		//	return new List<Movie>
		//	{
		//		new Movie { Id = 1, Name = "Shrek" },
		//		new Movie { Id = 2, Name = "Wall-e" }
		//	};
		//}

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