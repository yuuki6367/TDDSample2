namespace TDDSample.Web.Models.Rentals
{
    public sealed class NewReleaseFee : RentalFeeCalculator
    {
        public override int Fee(int daysRented)
        {
            return daysRented * 300;
        }
    }
}