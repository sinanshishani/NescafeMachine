using System;
using System.Collections.Generic;
using System.Text;

namespace NescafeMachine
{
    public class Quarter : CashBase
    {
        public override decimal Amount => 0.25m;

        public override CashBase Clone()
        {
            return new Quarter();
        }
    }
}
