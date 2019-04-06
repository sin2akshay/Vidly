﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Migrations;
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

		public ViewResult New()
		{
			var genres = _context.Genres.ToList();

			var viewModel = new MovieFormViewModel
			{
				Genres = genres
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
			{
				return HttpNotFound();
			}

			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm",viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = _context.Genres.ToList()
				};

				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
				movieInDb.ReleaseDate = movie.ReleaseDate;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");
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
	}
}