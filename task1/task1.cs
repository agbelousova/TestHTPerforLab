using System;
using System.Collections.Generic;
using System.Text;

namespace TestHTPerfLab.task1
{
    class task1
    {
        static void Main()
        {
            int n;
            bool isValidInput;

            do
            {
                Console.Write("Введите целое число n от 1 (длину интервала массива): ");
                string input = Console.ReadLine();
                isValidInput = int.TryParse(input, out n);

                if (!isValidInput)
                {
                    Console.WriteLine("Ошибка! Введите корректное целое число.");
                }
                else if (n < 1)
                {
                    Console.WriteLine("Ошибка! Число должно быть от 1.");
                    isValidInput = false;
                }
            } while (!isValidInput);

            Console.WriteLine($"Вы ввели число n = {n}");

            int m;

            do
            {
                Console.Write("Введите целое число m от 1 (количество интервалов массива): ");
                string input = Console.ReadLine();
                isValidInput = int.TryParse(input, out m);

                if (!isValidInput)
                {
                    Console.WriteLine("Ошибка! Введите корректное целое число.");
                }
                else if (m < 1)
                {
                    Console.WriteLine("Ошибка! Число должно быть от 1.");
                    isValidInput = false;
                }
            } while (!isValidInput);

            Console.WriteLine($"Вы ввели число m = {m}");

            // Генерируем путь
            var path = GeneratePath(n, m);

            // Выводим результат
            Console.WriteLine(path);
        }

        static string GeneratePath(int n, int m)
        {
            var path = new System.Text.StringBuilder();
            int current = 1; // Текущая начальная позиция

            for (int i = 0; i < n; i++)
            {
                path.Append(current);

                // Вычисляем следующую начальную позицию с учётом кругового массива
                current = (current + m - 1) % n + 1;
            }

            return path.ToString();

        }
    }
}
