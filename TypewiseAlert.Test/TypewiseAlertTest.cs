using System;
using Xunit;
using static TypewiseAlert.TypewiseConstants;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 20, 30) == BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.InferBreach(35, 20, 30) == BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.InferBreach(25, 20, 30) == BreachType.NORMAL);
        }
        [Fact]
        public void ClassifyTemperatureAsPerLimits()
        {
            Assert.True(TypewiseAlert.classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -1) == BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 10) == BreachType.NORMAL);
            Assert.True(TypewiseAlert.classifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 40) == BreachType.TOO_HIGH);
        }
        [Fact]
        public void CheckAlertAsPerLimits()
        {
            BatteryCharacter batteryCharacter;
            batteryCharacter.coolingType = CoolingType.MED_ACTIVE_COOLING;
            batteryCharacter.brand = "ETAS";
            Assert.True(TypewiseAlert.checkAndAlert(AlertTarget.TO_CONTROLLER, batteryCharacter, 20) == BreachType.NORMAL);
        }
    }
}
