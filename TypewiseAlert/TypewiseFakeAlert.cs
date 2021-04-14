using System;
using static TypewiseAlert.TypewiseConstants;

namespace TypewiseAlert
{
    public interface IFakeAlert
    {
        bool AlertBreach(BreachType breachType);
    }
    public class TriggerFakeAlert : IFakeAlert
    {
        public bool AlertBreach(BreachType breachType)
        {
            return true;
        }
    }
}
