using System;
using System.Collections.Generic;
using System.Text;

namespace NescafeMachine
{
    interface ICoffeeInventory
    {
        string RemoveSupplies(CoffeeBase coffee, int quantity);
        void ReturnSupplies(CoffeeBase coffee, int quantity);
    }
}
