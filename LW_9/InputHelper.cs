using System;

public static class InputHelper
{
    public static int ReadInt(string message)
    {
        int value;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }

            Console.WriteLine("Ошибка ввода числа.");
        }
    }

    public static string ReadString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string s = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(s))
            {
                return s;
            }

            Console.WriteLine("Пустая строка.");
        }
    }

    public static int ReadYear(string message)
    {
        int year;

        while (true)
        {
            year = ReadInt(message);

            if (year >= 1900 && year <= DateTime.Now.Year)
            {
                return year;
            }

            Console.WriteLine("Неверный год.");
        }
    }
}