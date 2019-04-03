using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		//We need a DbContext to access the Database
		private ApplicationDbContext _context;

		//We need to initialize the DbContext in Contructor
		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		//DbContext is a Disposable Object and we need to dispose it properly
		//Proper way is to override Dipose method of the base Controller class
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();

			var viewModel = new CustomerFormViewModel
			{
				MembershipTypes = membershipTypes
			};

			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		public ActionResult Create(Customer customer)
		{
			_context.Customers.Add(customer);
			_context.SaveChanges();

			return RedirectToAction("Index","Customers");
		}


		public ViewResult Index()
		{
			/*This Customers property is a DB defined in our DBContext, with this we can get all the Customers in the DB.
			 * When this line is executed EF is not gonna query the Database. The query is executed when we iterate over 
			 * the customers object. If we want the query to be executed here only, we will have to add .ToList().
			 */
			var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			return View(customers);
		}

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault( c => c.Id == id);

			if (customer == null)
			{
				return HttpNotFound();
			}

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			//Explicitly mentioning view that we need to return else it will look for view named Edit for this Action
			return View("CustomerForm", viewModel);
		}

		//Commenting this as we are now getting data from DB
		//private IEnumerable<Customer> GetCustomers()
		//{
		//	return new List<Customer>
		//	{
		//		new Customer { Id = 1, Name = "John Smith" },
		//		new Customer { Id = 2, Name = "Mary Williams" }
		//	};
		//}
		//Sql("UPDATE Customers SET Birthdate = CAST('1980-01-01' AS DATETIME) WHERE Id = 1");
	}
}