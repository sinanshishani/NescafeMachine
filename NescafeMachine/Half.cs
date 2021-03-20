namespace NescafeMachine
{
    public class Half : CashBase
    {
        public override decimal Amount => 0.5M;


        public override CashBase Clone()
        {
            return new Half();
        }
    }
}