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

            return $"{fee:N0} 円";
        }

        public int RentalFee()
        {
            var fee = 0;

            foreach (var rental in _rentals)
            {
                fee += rental.RentalFee();
            }

            return fee;
        }
    }
}