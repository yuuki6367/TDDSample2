namespace TDDSample.Web.Models.Rentals
{
    public sealed class RegularFee : RentalFeeCalculator
    {
        public override int Fee(int daysRented)
        {
            var baseFee = 200;

            if (daysRented > 2) baseFee += 200 * (daysRented - 2);

            return baseFee;
        }
    }
}