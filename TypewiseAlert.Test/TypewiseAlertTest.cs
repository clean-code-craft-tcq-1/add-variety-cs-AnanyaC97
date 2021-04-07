using System;
using Xunit;
using static TypewiseAlert.TypewiseConstants;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachLowAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 20, 30) == BreachType.TOO_LOW);
        }
        [Fact]
        public void InfersBreachHighAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(35, 20, 30) == BreachType.TOO_HIGH);
        }
        [Fact]
        public void InfersBreachNormalAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(25, 20, 30) == BreachType.NORMAL);
        }
        [Fact]
        public void ClassifyTemperaturelowAsPerLimits()
        {
            Assert.True(TypewiseAlert.classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -1) == BreachType.TOO_LOW);
        }
        [Fact]
        public void ClassifyTemperatureNormalAsPerLimits()
        {
            Assert.True(TypewiseAlert.classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 10) == BreachType.NORMAL);
        }
        [Fact]
        public void ClassifyTemperatureHighAsPerLimits()
        {
            Assert.True(TypewiseAlert.classifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 40) == BreachType.TOO_HIGH);
        }
        [Fact]
        public void CheckAlertAsPerLimits()
        {
            BatteryCharacter batteryCharacter =  new BatteryCharacter(CoolingType.MED_ACTIVE_COOLING, "ETAS");
            Assert.True(TypewiseAlert.checkAndAlert(AlertTarget.ALERT_TO_CONTROLLER, batteryCharacter, 20) == BreachType.NORMAL);
        }
    }
}
