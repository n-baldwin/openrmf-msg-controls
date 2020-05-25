using Xunit;
using openrmf_msg_controls.Models;
using System;

namespace tests.Models
{
    public class ControlTests
    {
        [Fact]
        public void Test_NewControlIsValid()
        {
            Control control = new Control();

            // Testing
            Assert.False(control == null);
        }
    
        [Fact]
        public void Test_ControlWithDataIsValid()
        {
            Control control = new Control();

            control.family = "AU-9";
            control.number = "AU-9";
            control.title = "Audit Control";
            control.lowimpact = true;
            control.moderateimpact = true;
            control.highimpact = true;
            control.supplementalGuidance = "Do this once and forever";
            control.id = Guid.NewGuid();

            // Testing
            Assert.True(control.family == "AU-9");
            Assert.True(control.number == "AU-9");
            Assert.True(control.title == "Audit Control");
            Assert.True(control.supplementalGuidance == "Do this once and forever");
            Assert.True(control.lowimpact);
            Assert.True(control.moderateimpact);
            Assert.True(control.highimpact);
            Assert.False(control.id == null);
            Assert.False(control.childControls == null);
        }

        [Fact]
        public void Test_NewChildControlIsValid()
        {
            ChildControl childControl = new ChildControl();

            // Testing
            Assert.False(childControl == null);
        }

        [Fact]
        public void Test_ChildControlWithDataIsValid()
        {
            ChildControl childControl = new ChildControl();

            childControl.description = "AU-9";
            childControl.number = "AU-9";

            // Testing
            Assert.True(childControl.description == "AU-9");
            Assert.True(childControl.number == "AU-9");
            Assert.False(childControl.id == null);
        }
    }
}
