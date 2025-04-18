# PracticeWork1
## ЭФМО-01-24 Шестериков Дмитрий Программирование корпоративных индустриальных систем
## Описание
Данное консольное приложение на C# предназначено для обработки текстовых файлов. Оно считывает содержимое указанного файла, подсчитывает общее количество слов и количество вхождений заданного слова.

## Использование
```sh
PracticeWork1 <путь_к_файлу> <слово_для_поиска>
```



### Пример запуска
```sh
PracticeWork1 text.txt пример
```

## Структура кода

### `Program`
Главный класс, содержащий метод `Main`.
1. Проверяет количество аргументов командной строки.
2. Передает путь к файлу и слово для поиска в класс `FileProcessor`.
3. Обрабатывает возможные ошибки.

### `FileProcessor`
Класс для работы с файлом.
- `ProcessFile(in string filePath, in string searchWord)`:
  - Открывает файл и читает его построчно.
  - Подсчитывает общее количество слов и количество вхождений заданного слова с помощью `TextProcessor`.
  - Выводит результаты в консоль.

### `TextProcessor`
Класс для обработки текста.
- `CountWords(in string text)`:
  - Использует регулярное выражение для подсчета всех слов в строке.
- `CountWordOccurrences(in string text, in string word)`:
  - Использует регулярное выражение для подсчета точных совпадений слова.

## Пример работы
**Файл `text.txt`**:
```
Привет, это пример текста для анализа.
В этом тексте мы будем искать слово "пример".
Слово "пример" может встречаться несколько раз.
Например, в этом предложении слово "пример" также присутствует.
```
**Запуск**:
```sh
PracticeWork1 text.txt пример
```
**Вывод в консоль**:
```
Общее количество слов в файле: 28
Количество повторений слова "пример": 4
```

## Обработка ошибок
- Если не переданы аргументы, выводится сообщение об использовании.
- Если файл не найден или произошла ошибка, программа выводит сообщение об ошибке.

## Система владения
- Конструкция using используется при работе с StreamReader для автоматического освобождения ресурсов после завершения работы с файлом, что предотвращает утечки памяти и улучшает управление ресурсами.


## Неизменяемые ссылки
- В методах ProcessFile, CountWords и CountWordOccurrences параметры передаются с модификатором in, что предотвращает их изменение и позволяет избежать ненужных копирований.
