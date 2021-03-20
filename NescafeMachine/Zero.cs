namespace NescafeMachine
{
    public class Zero : CashBase
    {
        public override decimal Amount => 0;

        public override CashBase Clone()
        {
            return new Zero();
        }
    }
}