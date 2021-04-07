using System;
using static TypewiseAlert.TypewiseConstants;

namespace TypewiseAlert
{
    public interface IAlertTarget
    {
        void AlertBreach(BreachType breachType);
    }
    public class ALERT_TO_CONTROLLER : IAlertTarget
    {
        public void AlertBreach(BreachType breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine("{0} : {1}\n", header, breachType);
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
