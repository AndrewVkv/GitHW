using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOf
{
    internal class Program
    {
        /*
         Задание 3. Индекс первого вхождения числа в массив. 
         Напишите метод, реализующий поиск первого вхождения числа в массив, и выведите в консоль его индекс или -1, если число не найдено.
         Массив: 81, 22, 13, 34, 10, 34, 15, 26, 71, 68
         Число 34
         */
        static void Main(string[] args)
        {
            // Example 1
            int number = 34;
            int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
            int index = Array.IndexOf(array, number);
            Console.WriteLine("Example 1");
            Console.WriteLine("Array");
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Index first in 34 is {index}");

            // Example 2
            Console.WriteLine();
            Console.WriteLine("Example 2");
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    Console.WriteLine($"Index first in 34 is {i}");
                    break;
                }

                if (array[i] != number)
                    counter++;
                if (counter == array.Length)
                    Console.WriteLine("Index first in 34 is -1");
            }

            Console.ReadKey();
        }
    }
}
