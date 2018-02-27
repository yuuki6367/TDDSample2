using TDDSample.Web.Models.Rentals;
using Xunit;

namespace TDDSample.Web.Tests
{
    public class RentalTest
    {
        private readonly Customer _taro;
        private readonly Movie _newRelease;
        private readonly Movie _regular;

        public RentalTest()
        {
            _newRelease = new Movie("スターウォーズ VIII", MovieRentalType.NewRelease);
            _taro = new Customer("taro");
            _regular = new Movie("スターウォーズ IV", MovieRentalType.Regular);

        }

        [Fact]
        public void 新作と普通を二泊借りたら800円()
        {
            _taro.AddRental(new Rental(_newRelease, 2));
            _taro.AddRental(new Rental(_regular, 2));

            var result = _taro.RentalFee();
            
            Assert.Equal(800, result);
        }

        [Fact]
        public void 金額にカンマが入る()
        {
            _taro.AddRental(new Rental(_newRelease, 4));

            var result = _taro.Statement();
            
            Assert.Equal("1,200 円", result);
        }
    }
}