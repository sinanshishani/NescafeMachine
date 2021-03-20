using System;
using System.Collections.Generic;
using System.Text;

namespace NescafeMachine
{
    public class TenCents : CashBase
    {
        public override decimal Amount => 0.1m;

        public override CashBase Clone()
        {
            return new TenCents();
        }
    }
}
