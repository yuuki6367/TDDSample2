using TDDSample.Web.Models.Rentals;
using Xunit;

namespace TDDSample.Web.Tests
{
    public class RegularFeeTest
    {
        private readonly RegularFee _regularFee;

        public RegularFeeTest()
        {
            _regularFee = new RegularFee();
        }

        [Fact]
        public void 普通を二泊借りたら200円()
        {
            var result = _regularFee.Fee(2);
            
            Assert.Equal(200, result);
        }

        [Fact]
        public void 普通を三泊借りたら400円()
        {
            var result = _regularFee.Fee(3);
            
            Assert.Equal(400, result);
        }

        [Fact]
        public void 普通を九泊借りたら1600円()
        {
            var result = _regularFee.Fee(9);
            
            Assert.Equal(1600, result);
        }
    }
}