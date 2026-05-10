using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class PhotoService
{
    public static List<Photo> Load(string path)
    {
        List<Photo> list = new List<Photo>();

        if (!File.Exists(path))
        {
            return list;
        }

        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                Photo p = new Photo();

                p.Name = reader.ReadString();
                p.Author = reader.ReadString();
                p.Year = reader.ReadInt32();
                p.Width = reader.ReadInt32();
                p.Height = reader.ReadInt32();

                list.Add(p);
            }
        }

        return list;
    }

    public static void Save(string path, List<Photo> list)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            for (int i = 0; i < list.Count; i++)
            {
                writer.Write(list[i].Name);
                writer.Write(list[i].Author);
                writer.Write(list[i].Year);
                writer.Write(list[i].Width);
                writer.Write(list[i].Height);
            }
        }
    }

    public static List<Photo> GetByAuthor(List<Photo> list, string author)
    {
        return list.Where(p => p.Author == author).ToList();
    }

    public static List<Photo> GetLargePhotos(List<Photo> list, int minWidth)
    {
        return list.Where(p => p.Width > minWidth).ToList();
    }

    public static int CountByAuthor(List<Photo> list, string author)
    {
        return list.Count(p => p.Author == author);
    }

    public static Photo GetLatestPhoto(List<Photo> list)
    {
        return list.OrderByDescending(p => p.Year).FirstOrDefault();
    }

    public static void Add(List<Photo> list, Photo photo)
    {
        list.Add(photo);
    }

    public static void RemoveByName(List<Photo> list, string name)
    {
        Photo p = list.FirstOrDefault(x => x.Name == name);

        if (p != null)
        {
            list.Remove(p);
        }
    }
}