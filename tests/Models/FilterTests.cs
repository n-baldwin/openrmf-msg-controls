using Xunit;
using openrmf_msg_controls.Models;
using System;

namespace tests.Models
{
    public class FilterTests
    {
        [Fact]
        public void Test_NewFilterIsValid()
        {
            Filter filter = new Filter();

            // Testing
            Assert.True(filter.impactLevel == "low");
            Assert.False(filter == null);
            Assert.False(filter.pii);
        }
    
        [Fact]
        public void Test_FilterWithDataIsValid()
        {
            Filter filter = new Filter();

            filter.impactLevel = "high";
            filter.pii = true;

            // Testing
            Assert.True(filter.impactLevel == "high");
            Assert.True(filter.pii);
        }

    }
}
