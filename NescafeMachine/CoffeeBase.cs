namespace NescafeMachine
{
    public abstract class CoffeeBase
    {
        private decimal price;

        public CoffeeBase(decimal price)
        {
            this.price = price;
        }
        public decimal GetPrice() => price;

    }
}
