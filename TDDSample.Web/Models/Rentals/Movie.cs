namespace TDDSample.Web.Models.Rentals
{
    public sealed class Movie
    {
        public string Name { get; }
        private MovieRentalType RentalType { get; }

        public Movie(string name, MovieRentalType rentalType)
        {
            Name = name;
            RentalType = rentalType;
        }
        
        public int RentalFee(int daysRented)
        {
            var fee = RentalFeeCalculator.FromRentalType(RentalType);

            return fee.Fee(daysRented);
        }
    }
}