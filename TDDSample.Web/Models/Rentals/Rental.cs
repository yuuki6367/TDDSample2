namespace TDDSample.Web.Models.Rentals
{
    public sealed class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        private Movie Movie { get; }
        private int DaysRented { get; }

        public int RentalFee()
        {
            return Movie.RentalFee(DaysRented);
        }
    }
}