using System.ComponentModel;

namespace TDDSample.Web.Models.Rentals
{
    public abstract class RentalFeeCalculator
    {
        public abstract int Fee(int daysRented);

        public static RentalFeeCalculator FromRentalType(MovieRentalType rentalType)
        {
            switch (rentalType)
            {
                case MovieRentalType.NewRelease: return new NewReleaseFee();
                case MovieRentalType.Regular: return new RegularFee();
                case MovieRentalType.Childrens: return new ChildrenFee();
                default: throw new InvalidEnumArgumentException();
            }
        }
    }
}