using System;
using System.Collections.Generic;
using System.Linq;

namespace NescafeMachine
{
    public abstract class CashBase
    {
        public abstract decimal Amount { get; }
        public int Count { get; set; }
        public abstract CashBase Clone();
    }
}
