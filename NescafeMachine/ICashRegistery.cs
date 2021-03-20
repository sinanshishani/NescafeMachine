using System;
using System.Collections.Generic;
using System.Text;

namespace NescafeMachine
{
    interface ICashRegistery
    {
        string Pay(List<CashBase> cash, decimal price);
    }
}
