using System;
using static TypeWiseAlert.TypewiseConstants;

namespace TypeWiseAlert
{
    public class TriggerFakeAlert : IAlertTarget
    {
        //AlertTarget alertTarget;
        //public TriggerFakeAlert(AlertTarget _alertTarget)
        //{
        //    alertTarget = _alertTarget;
        //}
        public bool isAlertBreachMethodCalled = false;
        public void AlertBreach(BreachType breachType)
        {
            isAlertBreachMethodCalled = true;
        }
    }
}
