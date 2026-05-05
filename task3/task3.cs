using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace TestHTPerfLab.task3
{
    internal class task3
    {
        static void Main()
        {
            Console.Write("Необходимо передать путь к values.Json: ");
            var valuesPath = Console.ReadLine();

            // Читаем values.Json
            var value = ReadValuesJson(valuesPath);
            if (value == null)
            {
                Console.WriteLine("Ошибка при чтении values.Json");
                return;
            }

            Console.Write("Необходимо передать путь к tests.Json: ");
            var testsPath = Console.ReadLine();

            // Читаем tests.Json
            var tests = ReadTestsJson(testsPath);
            if (tests == null)
            {
                Console.WriteLine("Ошибка при чтении tests.Json");
                return;
            }

            Console.Write("Необходимо передать путь к report.Json: ");
            var reportPath = Console.ReadLine();

            // Заполняем поля value в структуре tests на основе значений из value
            FillValuesInTests(tests, value);

            // Сохраняем итоговый отчёт в report.Json
            SaveReportJson(reportPath, tests);
        }

        static Dictionary<int, string> ReadValuesJson(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл {path} не найден.");

            string json = File.ReadAllText(path);
            var value = JsonSerializer.Deserialize<List<ValueItem>>(json);

            return value.ToDictionary(item => item.id, item => item.value);
        }

        static List<TestItem> ReadTestsJson(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл {path} не найден.");

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<TestItem>>(json);
        }

        static void FillValuesInTests(List<TestItem> tests, Dictionary<int, string> values)
        {
            foreach (var test in tests)
            {
                if (values.ContainsKey(test.id))
                    test.value = values[test.id];

                // Рекурсивно обрабатываем вложенные тесты
                if (test.values != null)
                    FillValuesInTests(test.values, values);
            }
        }

        static void SaveReportJson(string path, List<TestItem> tests)
        {
            string json = JsonSerializer.Serialize(tests, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }
    }

    // Классы для десериализации JSON
    public class ValueItem
    {
        public int id { get; set; }
        public string value { get; set; }
    }
    
    public class TestItem
    {
        public int id { get; set; }
        public string title { get; set; }
        public string? value { get; set; } // Может быть null, если значение не найдено
        public List<TestItem>? values { get; set; }
    }
}