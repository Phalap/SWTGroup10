using System;

namespace CalculatorClass
{
    public class Calculator
    {
        public double Accumulator { get; private set; } = 0; //Holds result of last calculation. Initialized as 0

        public double Add(double A, double B)
        {
            Accumulator = A + B;
            return A + B;
        }

        public double Subtract(double A, double B)
        {
            Accumulator = A - B;
            return A - B;
        }

        public double Multiply(double A, double B)
        {
            Accumulator = A * B;
            return A * B;
        }

        public double Power(double A, double B)
        {
            Accumulator = Math.Pow(A, B);
            return Math.Pow(A, B);
        }

        public double Divide(double dividend, double divisor)
        {
            if(divisor==0)
            {
                throw new System.DivideByZeroException();
            }
            Accumulator = dividend / divisor;
            return dividend / divisor;
        }

        public void Clear()
        {
            Accumulator = 0;
        }

        #region Overloads
        public double Add(double addend)
        {
            Accumulator += addend;
            return Accumulator;
        }
        public double Subtract(double subtractor)
        {
            Accumulator -= subtractor;
            return Accumulator;
        }
        public double Multiply(double multiplier)
        {
            Accumulator *= multiplier;
            return Accumulator;
        }
        public double Divide(double divisor)
        {
            Accumulator /= divisor;
            return Accumulator;
        }
        public double Power(double exponent)
        {
            Accumulator = this.Power(Accumulator, exponent);
            return Accumulator;
        }

        #endregion

    }
}
