using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string path = "photos.dat";
        List<Photo> photos = PhotoService.Load(path);
        string choice = "";

        while (choice != "0")
        {
            Console.WriteLine("\n1. Просмотр");
            Console.WriteLine("2. Добавить");
            Console.WriteLine("3. Удалить");
            Console.WriteLine("4. Запросы");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                if (photos.Count == 0)
                {
                    Console.WriteLine("Нет фотографий.");
                }
                else
                {
                    for (int i = 0; i < photos.Count; i++)
                        Console.WriteLine(photos[i]);
                }
            }
            else if (choice == "2")
            {
                string name = InputHelper.ReadString("Название: ");
                string author = InputHelper.ReadString("Автор: ");
                int year = InputHelper.ReadYear("Год: ");
                int width = InputHelper.ReadInt("Ширина: ");
                int height = InputHelper.ReadInt("Высота: ");

                Photo p = new Photo(name, author, year, width, height);

                PhotoService.Add(photos, p);
                PhotoService.Save(path, photos);
                Console.WriteLine("Фотография добавлена!");
            }
            else if (choice == "3")
            {
                if (photos.Count == 0)
                {
                    Console.WriteLine("Нет фотографий для удаления.");
                }
                else
                {
                    string name = InputHelper.ReadString("Удалить: ");
                    PhotoService.RemoveByName(photos, name);
                    PhotoService.Save(path, photos);
                    Console.WriteLine("Фотография удалена (если существовала).");
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("\n1. По автору");
                Console.WriteLine("2. Широкие фото");
                Console.WriteLine("3. Кол-во");
                Console.WriteLine("4. Последнее");

                string q = Console.ReadLine();

                if (q == "1")
                {
                    string author = InputHelper.ReadString("Автор: ");
                    var res = PhotoService.GetByAuthor(photos, author);

                    if (res.Count == 0)
                    {
                        Console.WriteLine("Фотографий не найдено.");
                    }
                    else
                    {
                        for (int i = 0; i < res.Count; i++)
                            Console.WriteLine(res[i]);
                    }
                }
                else if (q == "2")
                {
                    int w = InputHelper.ReadInt("Мин ширина: ");
                    var res = PhotoService.GetLargePhotos(photos, w);

                    if (res.Count == 0)
                    {
                        Console.WriteLine("Фотографий не найдено.");
                    }
                    else
                    {
                        for (int i = 0; i < res.Count; i++)
                            Console.WriteLine(res[i]);
                    }
                }
                else if (q == "3")
                {
                    string author = InputHelper.ReadString("Автор: ");
                    int count = PhotoService.CountByAuthor(photos, author);
                    Console.WriteLine($"Фотографий автора '{author}': {count}");
                }
                else if (q == "4")
                {
                    Photo latest = PhotoService.GetLatestPhoto(photos);
                    if (latest != null)
                        Console.WriteLine($"Последнее фото: {latest}");
                    else
                        Console.WriteLine("Фотографий нет");
                }
                else
                {
                    Console.WriteLine("Неверный выбор запроса.");
                }
            }
            else if (choice != "0")
            {
                Console.WriteLine("Неверный выбор. Попробуйте снова.");
            }
        }

        Console.WriteLine("До свидания!");
    }
}
