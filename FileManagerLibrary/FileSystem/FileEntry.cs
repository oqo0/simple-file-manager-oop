using FileManagerLibrary.FileSystem;

namespace FileManagerLibrary;

public class FileEntry
{
    public FileEntry(PathEntry path)
    {
        Path = path;
        
        GetName();
        GetSize();
        GetCreationDateTime();
        GetWords();
        GetLines();
        GetParagraphs();
        GetSymbols();
    }
    
    public PathEntry Path { get; }
    public string Name { get; private set; }
    public long Size { get; private set; }
    public DateTime CreationDateTime { get; private set; }
    public long Words { get; private set; }
    public long Lines { get; private set; }
    public long Paragraphs { get; private set; }
    public long Symbols { get; private set; }

    /// <summary>
    /// Получим имя файла
    /// </summary>
    private void GetName()
    {
        string filePath = Path.PathStr;
        Name = filePath.Split('/').Last();
    }

    /// <summary>
    /// Получим размер файла
    /// </summary>
    private void GetSize()
    {
        string filePath = Path.PathStr;
        Size = new FileInfo(filePath).Length;
    }

    /// <summary>
    /// Получим дату и время создания файла
    /// </summary>
    private void GetCreationDateTime()
    {
        CreationDateTime = File.GetCreationTime(Path.PathStr);
    }

    private void GetWords()
    {
        string fileText = File.ReadAllText(Path.PathStr);
        Words = fileText.Split(' ').Length;
    }

    private void GetLines()
    {
        string[] lines = File.ReadAllLines(Path.PathStr);
        Words = lines.Length;
    }
    
    private void GetParagraphs()
    {
        string fileText = File.ReadAllText(Path.PathStr);
        Paragraphs = fileText.Split("   ").Length;
    }

    private void GetSymbols()
    {
        string text = File.ReadAllText(Path.PathStr);
        Words = text.Length;
    }
    
    /// <summary>
    /// создать файл
    /// </summary>
    public static void Create(string path)
    {
        File.Create(path);
    }
    
    /// <summary>
    /// удалить файл
    /// </summary>
    public static void Delete(string path)
    {
        File.Delete(path);
    }
    
    /// <summary>
    /// переименовать файл
    /// </summary>
    /// <param name="oldName">полный путь к файлу с именем</param>
    /// <param name="newName">новое имя файла</param>
    public static void Rename(string oldName, string newName)
    {
        DirectoryInfo dir = Directory.GetParent(oldName);
        
        File.Move(oldName, dir.FullName + newName);
    }

    /// <summary>
    /// Копирование файла
    /// </summary>
    /// <param name="pathFrom"></param>
    /// <param name="pathWhere"></param>
    public static void Copy(string pathFrom, string pathWhere)
    {
        File.Copy(pathFrom, pathWhere);
    }

    public static void ChangeAttributes(string path, System.IO.FileAttributes fileAttributes)
    {
        File.SetAttributes(path, fileAttributes);
    }
}