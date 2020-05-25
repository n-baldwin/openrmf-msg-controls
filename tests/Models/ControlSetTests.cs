using Xunit;
using openrmf_msg_controls.Models;
using System;

namespace tests.Models
{
    public class ControlSetTests
    {
        [Fact]
        public void Test_NewControlIsValid()
        {
            ControlSet controlSet = new ControlSet();

            // Testing
            Assert.False(controlSet == null);
        }
    
        [Fact]
        public void Test_ControlWithDataIsValid()
        {
            ControlSet controlSet = new ControlSet();

            controlSet.family = "AU";
            controlSet.number = "AU-9";
            controlSet.title = "My Title";
            controlSet.priority = "low";
            controlSet.lowimpact = false;
            controlSet.moderateimpact = true;
            controlSet.highimpact = false;
            controlSet.supplementalGuidance = "My guidance";
            controlSet.subControlDescription = "My sub description";
            controlSet.subControlNumber = "AU-9.1(b)";

            // test things out
            Assert.True(controlSet.family == "AU");
            Assert.True(controlSet.number == "AU-9");
            Assert.True(controlSet.title == "My Title");
            Assert.True(controlSet.priority == "low");
            Assert.True(controlSet.supplementalGuidance == "My guidance");
            Assert.True(controlSet.subControlDescription == "My sub description");
            Assert.True(controlSet.subControlNumber == "AU-9.1(b)");
            Assert.True(controlSet.moderateimpact);
            Assert.False(controlSet.lowimpact);
            Assert.False(controlSet.highimpact);
            Assert.False(controlSet.id == null);
        }
    }
}
