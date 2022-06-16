using System;

namespace HW2._5
{
    internal class Program
    {
        /*
         Задание 1. Сумма чётных чисел заданного диапазона
        Напишите метод, реализующий подсчёт суммы чётных чисел в диапазоне от 7 до 21 включительно, и выведите в консоль результат.
        */
        static void Main(string[] args)
        {
            int from = 7;
            int to = 22;
            int result = Sum(from, to);
            Console.WriteLine($"Summ from 7 to 21 is { result}");
            Console.ReadKey();
        }
        private static int Sum(int numFrom, int numTo) 
        {
            int sum = 0;
            for (int i = numFrom; i < numTo; i++)
            {
                if (i % 2 == 0)
                    sum += i;
            }
            return sum;
        }
    }
}
