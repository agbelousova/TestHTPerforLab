using System;
using System.Collections.Generic;
using System.Text;

namespace TestHTPerfLab.task4
{
    class task4
    {
        static void Main()
        {
            // Читаем параметры эллипса из файла
            Console.Write("Введите полный путь к файлу с числами: ");

            // Читаем числа из файла
            int[] nums;
            try
            {
                nums = File.ReadAllText(Console.ReadLine())
               .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                return;
            }

            if (nums.Length == 0)
            {
                Console.WriteLine("Файл пуст.");
                return;
            }

            // Находим медиану
            int median = FindMedian(nums);

            // Считаем минимальное количество ходов
            long moves = nums.Sum(num => Math.Abs(num - median));

            // Выводим результат
            if (moves <= 20)
            {
                Console.WriteLine($"Минимальное количество ходов: {moves}");
            }
            else
            {
                Console.WriteLine("Невозможно привести все элементы к одному числу за 20 ходов.");
            }
        }

        static int FindMedian(int[] arr)
        {
            int[] sorted = arr.OrderBy(x => x).ToArray();
            int n = sorted.Length;
            return sorted[n / 2]; // Для нечётного количества — центральный элемент
        }
    }
}
