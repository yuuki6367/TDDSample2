using System.Collections.Generic;

namespace TDDSample.Web.Models.Rentals
{
    public sealed class Customer{
        private readonly List<Rental> _rentals = new List<Rental>();

        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }
        
        /**
         * レンタル金額を円で返す。
         */
        public string Statement()
        {
            var fee = RentalFee();
            return $"{fee:N0}円";
        }

        public int RentalFee()
        {
            var result = 0;
            foreach (var rental in _rentals)
            {
                result += RentalFee(rental);
            }
            return result;
        }

        private static int RentalFee(Rental rental)
        {
            var result = 0;

            switch (rental.Movie.RentalType)
            {
                case MovieRentalType.NewRelease:
                    result += rental.DaysRented * 300;
                    break;
                case MovieRentalType.Children:
                    result += 150;
                    for (var i = 3; i < rental.DaysRented; i++)
                    {
                        result += 150;
                    }

                    break;
                default:
                    result += 200;
                    for (var i = 2; i < rental.DaysRented; i++)
                    {
                        result += 200;
                    }

                    break;
            }

            return result;
        }
    }
}