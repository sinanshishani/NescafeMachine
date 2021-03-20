using System;
using System.Collections.Generic;
using System.Text;

namespace NescafeMachine
{
    public class One : CashBase
    {
        public override decimal Amount => 1;

        public override CashBase Clone()
        {
            return new One();
        }
    }
}
