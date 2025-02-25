using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Проверка, что аргументы коммандной строки переданы
        if (args.Length != 2)
        {
            Console.WriteLine("Использование: PracticeWork1 <путь_к_файлу> <слово_для_поиска>");
            return;
        }

        // Считывание пути и слова для поиска из аргументов коммандной строки
        string filePath = args[0];
        string searchWord = args[1];

        try
        {
            //Вызов метода для обработки файла
            FileProcessor.ProcessFile(filePath, searchWord);
        }
        catch (Exception ex)
        {
            // Обработка ошибки, если не найден файл или произошла другая ошибка
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}

class FileProcessor
{
    //Метод для обработки файла
    public static void ProcessFile(in string filePath, in string searchWord)
    {
        //Переменные для подсчета общего количества слов и повторений заданного слова
        int totalWords = 0;
        int occurrences = 0;
        //Приводим слово для поиска к нижнему регистру
        string searchWordLower = searchWord.ToLower();

        //Открытие файла
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            //Чтение файла построчно
            while ((line = reader.ReadLine()) != null)
            {
                //Подсчет общего числа слов
                totalWords += TextProcessor.CountWords(line);
                //Подсчет количества повторений слова в строке
                occurrences += TextProcessor.CountWordOccurrences(line, searchWordLower);

            }
            //Вывод ответа
            Console.WriteLine($"Общее количество слов в файле: {totalWords}");
            Console.WriteLine($"Количество повторений слова \"{searchWord}\": {occurrences}");
        }
    }
}

class TextProcessor
{
    //Метод для подсчета общего количество слов в тексте
    public static int CountWords(in string text)
    {
        string lowerText = text.ToLower();
        //Регулярное выражение находит все слова
        var matches = Regex.Matches(lowerText, @"\b[\wа-яА-ЯёЁ]+\b");
        return matches.Count;
    }

    //Метод для подсчета количества повторений заданного слова
    public static int CountWordOccurrences(in string text, in string word)
    {
        string lowerText = text.ToLower();
        //Используем регулярное выражение для поиска точного совпадения слова
        var matches = Regex.Matches(lowerText, $@"\b{Regex.Escape(word)}\b");
        return matches.Count;
    }
}
