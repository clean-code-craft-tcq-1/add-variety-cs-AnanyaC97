using System;
using Xunit;
using static TypeWiseAlert.TypewiseConstants;

namespace TypeWiseAlert.Test
{
    public class TypeWiseAlertTest
    {
        [Fact]
        public void InfersBreachLowAsPerLimits()
        {
            Assert.True(TypeWiseAlert.InferBreach(12, 20, 30) == BreachType.TOO_LOW);
        }
        [Fact]
        public void InfersBreachHighAsPerLimits()
        {
            Assert.True(TypeWiseAlert.InferBreach(35, 20, 30) == BreachType.TOO_HIGH);
        }
        [Fact]
        public void InfersBreachNormalAsPerLimits()
        {
            Assert.True(TypeWiseAlert.InferBreach(25, 20, 30) == BreachType.NORMAL);
        }
        [Fact]
        public void ClassifyTemperaturelowAsPerLimits()
        {
            Assert.True(TypeWiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -1) == BreachType.TOO_LOW);
        }
        [Fact]
        public void ClassifyTemperatureNormalAsPerLimits()
        {
            Assert.True(TypeWiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 10) == BreachType.NORMAL);
        }
        [Fact]
        public void ClassifyTemperatureHighAsPerLimits()
        {
            Assert.True(TypeWiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 40) == BreachType.TOO_HIGH);
        }
        [Fact]
        public void CheckAlertToController()
        {
            TypeWiseAlert.checkAndAlert(new ALERT_TO_CONTROLLER(), new BatteryCharacter(CoolingType.MED_ACTIVE_COOLING, "ETAS"), 20);
            TriggerFakeAlert fakeControllerAlert = new TriggerFakeAlert();
            fakeControllerAlert.AlertBreach(BreachType.NORMAL);
            Assert.True(fakeControllerAlert.isAlertBreachMethodCalled);
        }
        [Fact]
        public void CheckAlertToEmail()
        {
            TypeWiseAlert.checkAndAlert(new ALERT_TO_EMAIL(), new BatteryCharacter(CoolingType.MED_ACTIVE_COOLING, "ETAS"), 20);
            TriggerFakeAlert fakeEmailAlert = new TriggerFakeAlert();
            fakeEmailAlert.AlertBreach(BreachType.NORMAL);
            Assert.True(fakeEmailAlert.isAlertBreachMethodCalled);
        }
        [Fact]
        public void CheckAlertToConsole()
        {
            TypeWiseAlert.checkAndAlert(new ALERT_TO_CONSOLE(), new BatteryCharacter(CoolingType.MED_ACTIVE_COOLING, "ETAS"), 20);
            TriggerFakeAlert fakeConsoleAlert = new TriggerFakeAlert();
            fakeConsoleAlert.AlertBreach(BreachType.NORMAL);
            Assert.True(fakeConsoleAlert.isAlertBreachMethodCalled);
        }
        [Fact]
        public void CheckCompositeAlert()
        {
            CompositeAlert compositeAlerts = new CompositeAlert();
            compositeAlerts.AddNotifierToList(new ALERT_TO_CONTROLLER());
            compositeAlerts.AddNotifierToList(new ALERT_TO_EMAIL());
            compositeAlerts.AddNotifierToList(new ALERT_TO_CONSOLE());
            TypeWiseAlert.checkAndAlert(compositeAlerts, new BatteryCharacter(CoolingType.MED_ACTIVE_COOLING, "ETAS"), 20);
            TriggerFakeAlert fakeCompositeAlert = new TriggerFakeAlert();
            fakeCompositeAlert.AlertBreach(BreachType.NORMAL);
            Assert.True(fakeCompositeAlert.isAlertBreachMethodCalled);
        }
    }
}
