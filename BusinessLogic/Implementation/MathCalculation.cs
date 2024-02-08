
namespace BusinessLogic
{
    public class MathCalculation : IMathCalculation
    {
        public MathCalculation()
        {
            
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Substract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if(b == 0)
            {
                throw new Exception("Zero division not allowed");
            }
            return a / b;
        }

    }
}