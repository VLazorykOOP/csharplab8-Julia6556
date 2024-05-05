//Task 1
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Запитуємо користувача про вхідний та вихідний файли
        Console.Write("Введіть шлях до вхідного файлу: ");
        string inputFile = Console.ReadLine();
        Console.Write("Введіть шлях до вихідного файлу: ");
        string outputFile = Console.ReadLine();

        // Зчитуємо вміст вхідного файлу
        string inputText = File.ReadAllText(inputFile);

        // Пошук і підрахунок IP-адрес
        int count = 0;
        var regex = new Regex(@"\b(?:\d{1,3}\.){3}\d{1,3}\b");
        var matches = regex.Matches(inputText);
        foreach (Match match in matches)
        {
            count++;
        }

        // Заміна IP-адрес на підтекст "[IP_ADDRESS]"
        string modifiedText = regex.Replace(inputText, "[IP_ADDRESS]");

        // Записуємо змінений текст у вихідний файл
        File.WriteAllText(outputFile, modifiedText);

        // Виводимо кількість знайдених IP-адрес
        Console.WriteLine($"Знайдено IP-адрес: {count}");

        Console.WriteLine("Операція завершена успішно.");
    }
}
// Вхідний файл до програми: 
// Ласкаво просимо до нашої мережі!

// IP-адреса сервера: 192.168.0.1
// IP-адреса клієнта: 10.0.0.15
// IP-адреса доступу до бази даних: 172.16.254.1

// Будь ласка, звертайтеся до адміністратора за додатковою інформацією.

//Task 2

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть шлях до вхідного текстового файлу:");
        string inputFilePath = Console.ReadLine();

        // Перевірка чи існує файл
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        Console.WriteLine("Введіть шлях до вихідного текстового файлу:");
        string outputFilePath = Console.ReadLine();

        // Читання вмісту з вхідного файлу
        string text = File.ReadAllText(inputFilePath);

        // Видалення всіх знаків пунктуації та цифр за допомогою регулярного виразу
        string cleanText = Regex.Replace(text, @"[\p{P}\p{N}]", "");

        // Запис результату у новий файл
        try
        {
            File.WriteAllText(outputFilePath, cleanText);
            Console.WriteLine("Результат записано у файл: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при записі у файл: " + ex.Message);
        }
    }
}

// Вхідний файл до програми: Це приклад вхідного файлу. 

// Тут є деякі речення, які містять різні знаки пунктуації, 
// такі як крапки, коми, знаки питання та знаки оклику! 
// Також тут присутні числа, наприклад, 1234567890. 
// Ці символи потрібно видалити.

//Task 3

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть шлях до першого текстового файлу:");
        string firstFilePath = Console.ReadLine();

        Console.WriteLine("Введіть шлях до другого текстового файлу:");
        string secondFilePath = Console.ReadLine();

        // Перевірка чи існують файли
        if (!File.Exists(firstFilePath))
        {
            Console.WriteLine("Перший файл не знайдено.");
            return;
        }

        if (!File.Exists(secondFilePath))
        {
            Console.WriteLine("Другий файл не знайдено.");
            return;
        }

        try
        {
            // Зчитування вмісту файлів
            string firstText = File.ReadAllText(firstFilePath);
            string secondText = File.ReadAllText(secondFilePath);

            // Розділення текстів на слова за допомогою пробілів та розділових знаків
            string[] firstWords = firstText.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string[] secondWords = secondText.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Вилучення слів, що містяться в другому тексті, з першого тексту
            var filteredWords = firstWords.Where(word => !secondWords.Contains(word));

            // Запис результату у новий файл
            Console.WriteLine("Введіть шлях до файлу, куди буде записаний результат:");
            string outputFilePath = Console.ReadLine();

            File.WriteAllLines(outputFilePath, filteredWords);
            Console.WriteLine("Результат записано у файл: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}

// Вхідний файл до програми: Це приклад вхідного файлу. (2 файли)
// 1. 
//   Це перший текстовий файл. Він містить деякі слова, які можуть бути видалені.
// Наприклад, такі слова: це, деякі, можуть, бути.

// 2.
//   Це другий текстовий файл. Він містить деякі інші слова, які слід використовувати для видалення.
// Наприклад, такі слова: другий, файл, інші, слід.

//Task 4

using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть шлях до вхідного текстового файлу:");
        string inputFile = Console.ReadLine();

        Console.WriteLine("Введіть шлях до вихідного текстового файлу:");
        string outputFile = Console.ReadLine();

        try
        {
            // Зчитуємо дані з вхідного файлу
            string[] lines = File.ReadAllLines(inputFile);
            int[] numbers = Array.ConvertAll(lines, int.Parse);

            // Відкриваємо вихідний файл для запису парних чисел
            using (BinaryWriter writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
            {
                // Записуємо парні числа у вихідний файл
                foreach (int number in numbers)
                {
                    if (number % 2 == 0)
                    {
                        writer.Write(number);
                    }
                }
            }

            // Відкриваємо вихідний файл для читання та виводимо його вміст на екран
            using (BinaryReader reader = new BinaryReader(File.Open(outputFile, FileMode.Open)))
            {
                Console.WriteLine("Вміст вихідного файлу:");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int evenNumber = reader.ReadInt32();
                    Console.WriteLine(evenNumber);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}
 //Вхідний файл:
// 1
// 2
// 3
// 4
// 5
// 6
// 7
// 8
// 9
// 10







