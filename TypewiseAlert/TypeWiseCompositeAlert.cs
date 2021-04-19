using System;
using System.Collections.Generic;
using static TypeWiseAlert.TypewiseConstants;

namespace TypeWiseAlert
{
    public class CompositeAlert : IAlertTarget
    {
        List<IAlertTarget> _notifierList = new List<IAlertTarget>();
        public void AlertBreach(BreachType breachType)
        {
            foreach (IAlertTarget _notifier in _notifierList)
            {
                _notifier.AlertBreach(breachType);
            }
        }

        public void AddNotifierToList(IAlertTarget _notifier)
        {
            _notifierList.Add(_notifier);
        }
    }
}
