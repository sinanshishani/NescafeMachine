using System;
using System.Collections.Generic;

namespace NescafeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            ICashRegistery cashRegistery;
            ICoffeeInventory coffeeInventory;
            AddMoneyToRegistry();
            AddSuppliesToInventory();

            Console.WriteLine("to add milk press 1, to add milk and sugar press 2, or press enter without anything to have only coffee");
            var coffeType = Console.ReadLine();
            var milk = coffeType == "1";
            var milkAndSugar = coffeType == "2";

            Console.WriteLine("add quantity");
            var qty = int.Parse(Console.ReadLine());


            var cash = new List<CashBase>();
            InsertMoneyToMachine(cash);
            

            CoffeeBase coffee;
            //could be handled with abstract factory to send params and return type.
            if (!milk && !milkAndSugar)//coffee
            {
                coffee = new Coffee();
            }
            else if (milk)// milk
            {
                coffee = new CoffeeWithMilk();
            }
            else//milk and sugar
            {
                coffee = new CoffeeWithMilkAndSugar();
            }

            coffeeInventory = new CoffeeInventory();

            var hasSupplies = coffeeInventory.RemoveSupplies(coffee, qty) == "success";
            if (!hasSupplies)
                return;

            cashRegistery = new CashRegistery();

            var message = cashRegistery.Pay(cash, coffee.GetPrice() * qty);

            if (message != "success")
                coffeeInventory.ReturnSupplies(coffee, qty);


            Console.WriteLine(message);

            
        }

        private static void AddMoneyToRegistry()
        {
            CashRegistery.AvailableCash.Add(typeof(One).FullName, new One { Count = 10 });
            CashRegistery.AvailableCash.Add(typeof(Half).FullName, new Half { Count = 40 });
            CashRegistery.AvailableCash.Add(typeof(FiveCents).FullName, new FiveCents { Count = 1000 });
        }
        private static void AddSuppliesToInventory()
        {
            CoffeeInventory.AvailableSupplies.Add(typeof(Coffee).FullName, 10);
            CoffeeInventory.AvailableSupplies.Add(typeof(CoffeeWithMilk).FullName, 10);
            CoffeeInventory.AvailableSupplies.Add(typeof(CoffeeWithMilkAndSugar).FullName, 10);
        }

        private static void InsertMoneyToMachine(List<CashBase> cash)
        {
            Console.WriteLine("add money: 1, 0.5, 0.25, 0.1, 0.05");
            var money = decimal.Parse(Console.ReadLine());

            if (money == 1)
            {
                cash.Add(new One());
            }

            if (money == 0.5m)
            {
                cash.Add(new Half());
            }
            if (money == 0.25m)
            {
                cash.Add(new Quarter());
            }
            if (money == 0.1m)
            {
                cash.Add(new TenCents());
            }
            if (money == 0.05m)
            {
                cash.Add(new FiveCents());
            }


            Console.WriteLine("Do you want to add more money? y/n");
            var addMoreMoney = Console.ReadLine().ToLower() == "y";
            if (addMoreMoney)
                InsertMoneyToMachine(cash);
        }
    }
}
