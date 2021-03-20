using System;
using System.Collections.Generic;
using System.Text;

namespace NescafeMachine
{
    public class CoffeeInventory : ICoffeeInventory
    {
        public readonly static Dictionary<string, int> AvailableSupplies = new Dictionary<string, int>();
        public string RemoveSupplies(CoffeeBase coffee, int quantity)
        {
            string message = "success";
            if (!AvailableSupplies.ContainsKey(coffee.GetType().FullName) || AvailableSupplies[coffee.GetType().FullName] - quantity < 0)
                message =  $"Not Enough Supplies For Type : {coffee.GetType().Name}";

            AvailableSupplies[coffee.GetType().FullName] -= quantity;
            
            return message;
        }

        public void ReturnSupplies(CoffeeBase coffee, int quantity)
        {
            AvailableSupplies[coffee.GetType().FullName] += quantity;       
        }
    }
}
