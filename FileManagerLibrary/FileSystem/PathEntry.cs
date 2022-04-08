using System.Linq;

namespace FileManagerLibrary.FileSystem;

public class PathEntry
{
    public PathEntry(string path)
    {
        PathStr = path;
    }
    
    public string PathStr { get; private set; }
    
    /// <summary>
    /// Глубина вложенности в файловой системе
    /// </summary>
    public int Nesting
    {
        get => PathStr.Split('/').Length;
    }
    
    /// <summary>
    /// Очистить путь (вернуться в корневую директорию)
    /// </summary>
    public void Clear()
    {
        PathStr = "/";
    }

    /// <summary>
    /// Подняться на директорию выше
    /// </summary>
    public void GoUp()
    {
        DirectoryInfo dir = Directory.GetParent(PathStr);

        if (dir == null)
        {
            PathStr = "/";
            return;
        }
        
        PathStr = dir.FullName;
    }

    /// <summary>
    /// Открыть новую директорию
    /// Опускаемся на папку ниже относительно текущей
    /// </summary>
    /// <param name="directoryName">Имя папки, которую нужно открыть</param>
    public void Open(string directoryName)
    {
        if (Directory.Exists(PathStr + directoryName + "/"))
            PathStr += directoryName + "/";
    }
}