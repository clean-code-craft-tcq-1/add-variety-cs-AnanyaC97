using System;
using static TypeWiseAlert.TypewiseConstants;

namespace TypeWiseAlert
{
    public class TriggerFakeAlert : IAlertTarget
    {
        public bool isAlertBreachMethodCalled = false;
        public void AlertBreach(BreachType breachType)
        {
            isAlertBreachMethodCalled = true;
        }
    }
}
