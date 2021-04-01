using System;
using static TypewiseAlert.TypewiseConstants;


namespace TypewiseAlert
{
    public interface ICoolingClassify
    {
        int GetLowerLimit { get; }
        int GetUpperLimit { get; }
    }
    public class PASSIVE_COOLING : ICoolingClassify
    {
        public int GetLowerLimit { get { return 0; } }
        public int GetUpperLimit { get { return 35; } }
    }
    public class HI_ACTIVE_COOLING : ICoolingClassify
    {
        public int GetLowerLimit { get { return 0; } }
        public int GetUpperLimit { get { return 45; } }
    }
    public class MED_ACTIVE_COOLING : ICoolingClassify
    {
        public int GetLowerLimit { get { return 0; } }
        public int GetUpperLimit { get { return 40; } }
    }
    public interface IAlertTarget
    {
        void AlertBreach(BreachType breachType);
    }
    public class ALERT_TO_CONTROLLER : IAlertTarget
    {
        public void AlertBreach(BreachType breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine("{} : {}\n", header, breachType);
        }
    }
    public class ALERT_TO_EMAIL : IAlertTarget
    {
        public void AlertBreach(BreachType breachType)
        {
            DisplayAlertStatus(breachType, "a.b@c.com");
        }
        public void DisplayAlertStatus(BreachType breachType, string recepient)
        {
            Console.WriteLine("To: {}\n", recepient);
            Console.WriteLine($"Hi, the temperature is {breachType} \n");
        }
    }
}
