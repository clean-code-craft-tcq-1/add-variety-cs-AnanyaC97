using System;
using System.Reflection;
using static TypeWiseAlert.TypewiseConstants;

namespace TypeWiseAlert
{
    public class TypeWiseAlert
    {
        public class FindObjectInstance
        {
            public static Object FindInstance(string className)
            {
                Assembly assemblyName = Assembly.Load(Assembly.GetExecutingAssembly().GetName());
                foreach (Type type in assemblyName.GetTypes())
                {
                    if (type.Name.Contains(className))
                    {
                        return Activator.CreateInstance(type);
                    }
                }
                return null;
            }
        }
        public static BreachType InferBreach(double value, double lowerLimit, double upperLimit)
        {
            return value < lowerLimit ? BreachType.TOO_LOW : CheckBreachLimit(value, upperLimit);
        }
        public static BreachType CheckBreachLimit(double value, double upperLimit)
        {
            return value > upperLimit ? BreachType.TOO_HIGH : BreachType.NORMAL;
        }
        public static BreachType ClassifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
        {
            ICoolingClassify coolingClassify = FindObjectInstance.FindInstance(coolingType.ToString()) as ICoolingClassify;
            return InferBreach(temperatureInC, coolingClassify.GetLowerLimit, coolingClassify.GetUpperLimit);
        }
        public static void checkAndAlert(IAlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            alertTarget.AlertBreach(breachType);
        }
    }
}
