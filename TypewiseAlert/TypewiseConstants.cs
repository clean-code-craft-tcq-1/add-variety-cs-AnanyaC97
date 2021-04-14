using System;
namespace TypewiseAlert
{
    public class TypewiseConstants
    {
        public enum BreachType
        {
            NORMAL,
            TOO_LOW,
            TOO_HIGH
        };
        public enum CoolingType
        {
            PASSIVE_COOLING,
            HI_ACTIVE_COOLING,
            MED_ACTIVE_COOLING
        };
        public enum AlertTarget
        {
            ALERT_TO_CONTROLLER,
            ALERT_TO_EMAIL,
            ALERT_TO_CONSOLE
        };
        public struct BatteryCharacter
        {
            public CoolingType coolingType;
            public string brand;
            public BatteryCharacter(CoolingType coolingType, string brand)
            {
                this.coolingType = coolingType;
                this.brand = brand;
            }
        }
    }
}
