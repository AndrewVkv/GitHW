using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    internal class Program
    {
        /*
         Задание 4. Сортировка выбором*
        Реализуйте метод сортировки массива методом выбора. 
        Алгоритм: на каждой итерации в последовательности неотсортированных данных выбирается минимальный элемент и 
        помещается в первую позицию неотсортированной последовательности. Выведите в консоль исходный массив и отсортированный массив.
        Массив: 81, 22, 13, 34, 10, 34, 15, 26, 71, 68
         */
        static void Main(string[] args)
        {
            int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
            Console.WriteLine("Oroginal Array:");
            COouArray(originalArray);
            Console.WriteLine();
            SortArray(originalArray);
            Console.WriteLine("Sorted Array:");
            COouArray(originalArray);
            Console.ReadKey();
        }
        public static void COouArray(int[] array) 
        {
            foreach (int item in array)
            {
                Console.Write($"{item} \t");
            }
        }
        public static void SortArray(int[] array) 
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }
                if (minIndex != i)
                {
                    int tempValue = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = tempValue;
                }
            }
        }
    }
}
