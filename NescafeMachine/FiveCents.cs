namespace NescafeMachine
{
    public class FiveCents : CashBase
    {
        public override decimal Amount => 0.05M;

        public override CashBase Clone()
        {
           return new FiveCents();
        }
    }
}
