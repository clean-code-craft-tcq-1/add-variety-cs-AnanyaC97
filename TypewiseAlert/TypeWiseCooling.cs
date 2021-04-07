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
}
