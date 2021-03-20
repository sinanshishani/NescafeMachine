using System.Collections.Generic;
using System.Linq;

namespace NescafeMachine
{
    public class CashRegistery : ICashRegistery
    {
        public readonly static Dictionary<string, CashBase> AvailableCash = new Dictionary<string, CashBase>();
        private void InsertToRegistery(CashBase cash)
        {
            if (!AvailableCash.ContainsKey(cash.GetType().FullName))
                AvailableCash[cash.GetType().FullName] = cash;

            AvailableCash[cash.GetType().FullName].Count++;
        }

        public string Pay(List<CashBase> cash, decimal price)
        {
            bool isEnough = IsEnough(cash, price);
            if (!isEnough) return "the amount is not enough for the purchase";

            foreach (var item in cash)
            {
                InsertToRegistery(item);
            }

            List<CashBase> change = GetChange(cash, price);
            if (change == null)
            {

                foreach (var item in cash)
                {
                    RemoveFromRegistery(item);
                }
                return "no enough money for the change";
            }
            return "success";
        }

        private void RemoveFromRegistery(CashBase cash)
        {
            AvailableCash[cash.GetType().FullName].Count--;
        }

        private List<CashBase> GetChange(List<CashBase> cash, decimal price)
        {
            var changeAmount = cash.Sum(c => c.Amount) - price;
            if (changeAmount == 0) return new List<CashBase> { new Zero() };
            var change = new List<CashBase>();

            foreach (var availableCach in AvailableCash.Select(c => c.Value).Where(c => c.Count > 0))
            {
                for (var i = 0; i < availableCach.Count; i++)//should be recursive
                {
                    var result = availableCach.Amount;

                    if (changeAmount - result < 0)
                        break;

                    var changeRef = change.SingleOrDefault(a => a.GetType().FullName == availableCach.GetType().FullName);
                    if (changeRef != null)
                        changeRef.Count++;
                    else
                        change.Add(availableCach.Clone());

                    RemoveFromRegistery(availableCach);
                    changeAmount -= result;

                    if (changeAmount == 0)
                        break;
                }

                if (changeAmount == 0)
                    break;
            }

            return changeAmount == 0 ? change : null;
        }


        private bool IsEnough(List<CashBase> cash, decimal price)
        {
            var cashAmount = cash.Sum(c => c.Amount);
            return cashAmount >= price;
        }
    }
}
