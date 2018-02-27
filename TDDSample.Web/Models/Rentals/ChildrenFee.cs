using System;

namespace TDDSample.Web.Models.Rentals
{
    public class ChildrenFee : RentalFeeCalculator
    {
        public override int Fee(int daysRented)
        {
            throw new NotImplementedException();
        }
    }
}