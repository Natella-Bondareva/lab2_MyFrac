using System;


namespace lab2_MyFrac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть дріб:");
            MyFrac myFrac = new MyFrac(long.Parse(Console.ReadLine()), long.Parse(Console.ReadLine()));
            Console.WriteLine("Дріб, який ви ввели:" + myFrac.ToString());
            Console.WriteLine("Дріб з цілою частиною:" + myFrac.ToStringWithIntegerPart());
            Console.WriteLine($"Десятковий дріб:{myFrac.DoubleValue()}");
            Console.WriteLine("Введіть для додавання:");
            MyFrac myFracPlus = new MyFrac(long.Parse(Console.ReadLine()), long.Parse(Console.ReadLine()));
            Console.WriteLine("Дріб, до якого додали щойновведений дріб:" + myFrac.Plus(myFracPlus).ToString());
            Console.WriteLine("Введіть для віднімання:");
            MyFrac myFracMinus = new MyFrac(long.Parse(Console.ReadLine()), long.Parse(Console.ReadLine()));
            Console.WriteLine("Дріб від якого відняли щойновведений дріб:" + myFrac.Minus(myFracMinus).ToString());
            Console.WriteLine("Введіть для множення:");
            MyFrac myFracMultiply = new MyFrac(long.Parse(Console.ReadLine()), long.Parse(Console.ReadLine()));
            Console.WriteLine("Дріб, до якого домножили щойновведений дріб:" + myFrac.Multiply(myFracMultiply).ToString());
            Console.WriteLine("Введіть для ділення:");
            MyFrac myFracDivide = new MyFrac(long.Parse(Console.ReadLine()), long.Parse(Console.ReadLine()));
            Console.WriteLine("Дріб, який поділили на щойновведений дріб:" + myFrac.Divide(myFracDivide).ToString());
            Console.WriteLine("Введіть n:");
            Console.WriteLine($"Результат виконання методу CalcSum1: {myFrac.CalcSum1(int.Parse(Console.ReadLine()))}");
            Console.WriteLine("Введіть n:");
            Console.WriteLine($"Результат виконання методу CalcSum2: {myFrac.CalcSum2(int.Parse(Console.ReadLine()))}");
        }


    }
}