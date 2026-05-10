using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string path = "photos.dat";
        List<Photo> photos = PhotoService.Load(path);

        while (true)
        {
            Console.WriteLine("\n1. Просмотр");
            Console.WriteLine("2. Добавить");
            Console.WriteLine("3. Удалить");
            Console.WriteLine("4. Запросы");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                for (int i = 0; i < photos.Count; i++)
                    Console.WriteLine(photos[i]);
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
            }
            else if (choice == "3")
            {
                string name = InputHelper.ReadString("Удалить: ");

                PhotoService.RemoveByName(photos, name);
                PhotoService.Save(path, photos);
            }
            else if (choice == "4")
            {
                Console.WriteLine("1. По автору");
                Console.WriteLine("2. Широкие фото");
                Console.WriteLine("3. Кол-во");
                Console.WriteLine("4. Последнее");

                string q = Console.ReadLine();

                if (q == "1")
                {
                    string author = InputHelper.ReadString("Автор: ");
                    var res = PhotoService.GetByAuthor(photos, author);

                    for (int i = 0; i < res.Count; i++)
                        Console.WriteLine(res[i]);
                }
                else if (q == "2")
                {
                    int w = InputHelper.ReadInt("Мин ширина: ");
                    var res = PhotoService.GetLargePhotos(photos, w);

                    for (int i = 0; i < res.Count; i++)
                        Console.WriteLine(res[i]);
                }
                else if (q == "3")
                {
                    string author = InputHelper.ReadString("Автор: ");
                    Console.WriteLine(PhotoService.CountByAuthor(photos, author));
                }
                else if (q == "4")
                {
                    Console.WriteLine(PhotoService.GetLatestPhoto(photos));
                }
            }
            else if (choice == "0")
            {
                break;
            }
        }
    }
}