using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDDSample.Web.Models;
using TDDSample.Web.Models.Rentals;

namespace TDDSample.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeViewModel(Movies, Customer));
        }

        [HttpPost]
        public IActionResult Add([FromForm] string selectedItemId, [FromForm] int daysRented)
        {
            Customer.AddRental(new Rental(FindMovie(selectedItemId), daysRented));
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        #region Customers

        private static Customer FindCustomer(string id)
        {
            if (!Customers.TryGetValue(id, out var customer))
            {
                customer = new Customer("太郎");
                Customers.Add(id, customer);
            }

            return customer;
        }

        private string CustomerId {
            get
            {
                var id = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(id))
                {
                    id = Guid.NewGuid().ToString();
                    HttpContext.Session.SetString("CustomerId", id);
                }

                return id;
            }
        }
        
        private Customer Customer => FindCustomer(CustomerId);
        private static readonly IDictionary<string, Customer> Customers = new Dictionary<string, Customer>();

        #endregion
        
        #region Movies

        private static readonly Movie[] Movies =
        {
            new Movie("スターウォーズ IV", MovieRentalType.Regular),
            new Movie("スターウォーズ VIII", MovieRentalType.NewRelease),
            new Movie("親指スターウォーズ", MovieRentalType.Children)
        };

        private static Movie FindMovie(string id)
        {
            return Movies.FirstOrDefault(m => m.Id == id);
        }

        #endregion
    }
}