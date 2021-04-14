using System;
using System.Reflection;
using static TypewiseAlert.TypewiseConstants;

namespace TypewiseAlert
{
    public class TypewiseAlert
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
        public static BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
        {
            ICoolingClassify coolingClassify = FindObjectInstance.FindInstance(coolingType.ToString()) as ICoolingClassify;
            return InferBreach(temperatureInC, coolingClassify.GetLowerLimit, coolingClassify.GetUpperLimit);
        }
        public static void checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            IAlertTarget alert = FindObjectInstance.FindInstance(alertTarget.ToString()) as IAlertTarget;
            alert.AlertBreach(classifyTemperatureBreach(batteryChar.coolingType, temperatureInC));
        }
    }
}
