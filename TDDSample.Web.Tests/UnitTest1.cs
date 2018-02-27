using Xunit;

namespace TDDSample.Web.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result = 1 + 1;
            
            Assert.Equal(result, 2);
        }
    }
}