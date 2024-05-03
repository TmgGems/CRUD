namespace Practice.DI
{
    public class SimpleInterest : ISimpleInterest
    {
        public decimal Calculate(decimal Prinicipal, int period, decimal rate)
        {
            return Prinicipal * period * rate / 100;
        }
    }
}
