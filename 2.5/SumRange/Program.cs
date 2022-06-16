using System;

namespace SumRange
{
    internal class Program
    {
        /*
        Задание 2. Сумма чётных чисел в заданном массиве
        Массив:  81, 22, 13, 54, 10, 34, 15, 26, 71, 68 
        */
        static void Main(string[] args)
        {
            int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    sum += array[i];

            }

            Console.WriteLine("Array: ");
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Sum even numbers array is {sum}");
            Console.ReadKey();
        }
    }
}
