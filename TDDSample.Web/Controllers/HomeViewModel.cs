using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TDDSample.Web.Models.Rentals;

namespace TDDSample.Web.Controllers
{
    public sealed class HomeViewModel
    {
        public HomeViewModel(IEnumerable<Movie> movies, Customer customer)
        {
            Customer = customer;
            Movies = SelectList(movies);
            SelectedMovieId = "";
        }

        public Customer Customer { get; }
        public SelectList Movies { get; }
        public string SelectedMovieId { get; set; }
        public int DaysRented { get; set; }

        private SelectList SelectList(IEnumerable<Movie> movies)
        {
            var items = new ArrayList {new {Id = "", Value = "選択してください"}};
            items.AddRange(movies.Select(movie => new {movie.Id, Value = movie.Name}).ToArray());

            return new SelectList(items, "Id", "Value");
        }
    }
}