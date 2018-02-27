using TDDSample.Web.Models.Rentals;
using Xunit;

namespace TDDSample.Web.Tests
{
    public class NewReleaseFeeTest
    {
        private NewReleaseFee _newReleaseFee;

        public NewReleaseFeeTest()
        {   
            _newReleaseFee = new NewReleaseFee();
        }

        [Fact]
        public void 新作を一日借りたら300円()
        {
            var result = _newReleaseFee.Fee(1);
            
            Assert.Equal(300, result);
        }

        [Fact]
        public void 新作を三日借りたら900円()
        {
            var result = _newReleaseFee.Fee(3);
            
            Assert.Equal(900, result);
        }
    }
}