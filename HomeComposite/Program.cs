using System;
using System.Collections.Generic;

abstract class FileSystemComponent
{
    public string Name { get; set; }

    public FileSystemComponent(string name)
    {
        Name = name;
    }

    public abstract void Display(int indent = 0);
    public abstract int GetSize();
}

class File : FileSystemComponent
{
    public int Size { get; private set; }

    public File(string name, int size) : base(name)
    {
        Size = size;
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine(new String(' ', indent) + $"Файл: {Name} (Размер: {Size})");
    }

    public override int GetSize() => Size;
}

class Directory : FileSystemComponent
{
    private List<FileSystemComponent> components = new List<FileSystemComponent>();

    public Directory(string name) : base(name) { }

    public void Add(FileSystemComponent component)
    {
        if (!components.Contains(component))
        {
            components.Add(component);
        }
    }

    public void Remove(FileSystemComponent component)
    {
        components.Remove(component);
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine(new String(' ', indent) + $"Папка: {Name}");
        foreach (var component in components)
        {
            component.Display(indent + 2);
        }
    }

    public override int GetSize()
    {
        int totalSize = 0;
        foreach (var component in components)
        {
            totalSize += component.GetSize();
        }
        return totalSize;
    }
}

class Program
{
    static void Main()
    {
        var rootDir = new Directory("Root");

        var documents = new Directory("Documents");
        documents.Add(new File("Resume.pdf", 120));
        documents.Add(new File("ProjectPlan.docx", 350));

        var pictures = new Directory("Pictures");
        pictures.Add(new File("Vacation.jpg", 2000));
        pictures.Add(new File("Profile.png", 500));

        rootDir.Add(documents);
        rootDir.Add(pictures);

        var downloads = new Directory("Downloads");
        downloads.Add(new File("Setup.exe", 15000));
        downloads.Add(new File("Guide.pdf", 700));

        rootDir.Add(downloads);

        Console.WriteLine("Содержимое файловой системы:");
        rootDir.Display();

        Console.WriteLine($"\nОбщий размер файловой системы: {rootDir.GetSize()} KB");
    }
}
