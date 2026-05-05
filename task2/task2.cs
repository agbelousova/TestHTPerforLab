using System;
using System.IO;
using System.Collections.Generic;
/*
namespace TestHTPerfLab.task2
{
    class task2
    {
        static void Main()
        {
            // Читаем параметры эллипса из файла 1
            Console.Write("Введите полный путь к файлу с параметрами эллипса: ");
            var ellipseParams = ReadEllipseParams(Console.ReadLine());
            double xc = ellipseParams.x_center;
            double yc = ellipseParams.y_center;
            double a = ellipseParams.a;
            double b = ellipseParams.b;

            // Читаем точки из файла 2
            Console.Write("Введите полный путь к файлу с координатами точек: ");
            var points = ReadPoints(Console.ReadLine());

            // Обрабатываем каждую точку и записываем результат
            List<int> results = new List<int>();
            foreach (var point in points)
            {
                double x = point.x;
                double y = point.y;

                double value = Math.Pow(x - xc, 2) / Math.Pow(a, 2) +
                Math.Pow(y - yc, 2) / Math.Pow(b, 2);

                if (Math.Abs(value - 1) < 1e-9)
                {
                    results.Add(0); // на эллипсе
                    Console.WriteLine($"Точка на элипсе ({results[0]})");
                }
                else if (value < 1)
                {
                    results.Add(1); // внутри
                    Console.WriteLine($"Точка внутри элипса ({results[1]})");
                }
                else
                {
                    results.Add(2); // снаружи
                    Console.WriteLine($"Точка снаружи элипса ({results[2]})");
                }
            }
        }

        // Структура для параметров эллипса
        struct EllipseParams
        {
            public double x_center;
            public double y_center;
            public double a;
            public double b;
        }

        static EllipseParams ReadEllipseParams(string filePath)
        {
            // Проверяем существование файла
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден:" + filePath);
            }

            string[] lines = File.ReadAllLines(filePath);

            // Проверяем, что в файле ровно 2 строки
            if (lines.Length != 2)
            {
                throw new InvalidDataException("В файле должно быть ровно 2 строки с координатами точек.");
            }

            double x_center, y_center, a, b;

            // Читаем первую точку
            var parts1 = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts1.Length != 2 ||
           !Double.TryParse(parts1[0], out x_center) ||
           !Double.TryParse(parts1[1], out y_center))
            {
                throw new FormatException("Первая строка должна содержать 2 числа, разделённые пробелом.");
            }

            // Читаем вторую точку
            var parts2 = lines[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts2.Length != 2 ||
           !Double.TryParse(parts2[0], out a) ||
           !Double.TryParse(parts2[1], out b))
            {
                throw new FormatException("Вторая строка должна содержать 2 числа, разделённые пробелом.");
            }

            return new EllipseParams
            {
                x_center = x_center,
                y_center = y_center,
                a = a,
                b = b
            };
        }

        // Структура для точки
        struct Point
        {
            public double x;
            public double y;
        }

        // Чтение точек из файла
        static List<Point> ReadPoints(string filePath)
        {
            // Проверяем существование файла
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден:" + filePath);
            }

            List<Point> points = new List<Point>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                points.Add(new Point
                {
                    x = double.Parse(parts[0]),
                    y = double.Parse(parts[1])
                });
            }
            return points;
        }
    }
}
*/