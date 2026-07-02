using System;
namespace GS
{
    // generic calculator class
    public class Calculator<T>
    {
        private T num;

        // constructor
        public Calculator(T num)
        {
            this.num = num;
        }

        public T Num
        {
            get { return num; }
            set { num = value; }
        }

        // add
        public static Calculator<T> operator +(Calculator<T> a, Calculator<T> b)
        {
            dynamic x = a.num;
            dynamic y = b.num;
            return new Calculator<T>((T)(x + y));
        }

        // subtract
        public static Calculator<T> operator -(Calculator<T> a, Calculator<T> b)
        {
            dynamic x = a.num;
            dynamic y = b.num;
            return new Calculator<T>((T)(x - y));
        }

        // multiply
        public static Calculator<T> operator *(Calculator<T> a, Calculator<T> b)
        {
            dynamic x = a.num;
            dynamic y = b.num;
            return new Calculator<T>((T)(x * y));
        }

        // divide
        public static Calculator<T> operator /(Calculator<T> a, Calculator<T> b)
        {
            dynamic x = a.num;
            dynamic y = b.num;
            if (y == 0)
            {
                throw new DivideByZeroException("can't divide by 0");
            }
            return new Calculator<T>((T)(x / y));
        }

        // output
        public override string ToString()
        {
            return num.ToString();
        }
    }

    internal class GenericCalculator
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number: ");
            double n2 = Convert.ToDouble(Console.ReadLine());
            Calculator<double> num1 = new Calculator<double>(n1);
            Calculator<double> num2 = new Calculator<double>(n2);

            Console.WriteLine("Number 1: " + num1.ToString());
            Console.WriteLine("Number 2: " + num2.ToString());


            try
            {
                Calculator<double> sum = num1 + num2;
                Console.WriteLine("a + b: " + sum.ToString());

                Calculator<double> diff = num1 - num2;
                Console.WriteLine("a - b: " + diff.ToString());

                Calculator<double> product = num1 * num2;
                Console.WriteLine("a * b: " + product.ToString());

                Calculator<double> quotient = num1 / num2;
                Console.WriteLine("a / b: " + quotient.ToString());
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}