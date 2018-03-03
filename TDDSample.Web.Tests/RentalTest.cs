using Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal.Networking;
using SQLitePCL;
using TDDSample.Web.Models.Rentals;
using Xunit;

namespace TDDSample.Web.Tests
{
    public class RentalTest
    {
        private readonly Movie _movie;
        private readonly Customer _customer;

        public RentalTest()
        {
            _movie = new Movie("アウトレイジ ビヨンド", MovieRentalType.NewRelease);
            _customer = new Customer("太郎");
        }

        [Fact]
        public void 新作を一泊借りたら300円()
        {
            _customer.AddRental(new Rental(_movie, 1));

            var result = _customer.Statement();

            Assert.Equal("300円", result);
        }

        [Fact]
        public void 新作を三泊借りたら900円()
        {
            _customer.AddRental(new Rental(_movie, 3));

            var result = _customer.RentalFee();

            Assert.Equal(900, result);
        }

        [Fact]
        public void 整形1200円にはカンマが入る()
        {
            _customer.AddRental(new Rental(_movie, 4));

            var result = _customer.Statement();

            Assert.Equal("1,200円", result);
        }

        [Fact]
        public void 普通を二泊借りたら200円()
        {
            _customer.AddRental(new Rental(new Movie("釣りバカ日誌", MovieRentalType.Regular), 2));

            var result = _customer.RentalFee();

            Assert.Equal(200, result);
        }

        [Fact]
        public void 普通を三泊借りたら400円()
        {
            _customer.AddRental(new Rental(new Movie("釣りバカ日誌", MovieRentalType.Regular), 3));

            var result = _customer.RentalFee();

            Assert.Equal(400, result);
        }

        [Fact]
        public void 新作を一泊と普通を二泊借りたら500円()
        {
            _customer.AddRental(new Rental(new Movie("シンゴジラ", MovieRentalType.NewRelease), 1));
            _customer.AddRental(new Rental(new Movie("釣りバカ日誌", MovieRentalType.Regular), 2));

            var result = _customer.RentalFee();

            Assert.Equal(500, result);
        }
        
        [Fact]
        public void 子供が三泊借りたら150円()
        {
            _customer.AddRental(new Rental(new Movie("釣りバカ日誌", MovieRentalType.Children), 3));

            var result = _customer.RentalFee();

            Assert.Equal(150, result);
        }
    }
}