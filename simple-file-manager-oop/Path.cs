namespace simple_file_manager_oop;

public class Path
{
    private static string _fullPath = "/";

    public static string fullPath
    {
        get
        {
            return _fullPath;
        }
        set
        {
            _fullPath = value;
        }
    }
    
    /// <summary>
    /// Очистить существующий путь
    /// </summary>
    public static void Clear()
    {
        _fullPath = String.Empty; 
    }

    /// <summary>
    /// Переместиться в папку
    /// </summary>
    /// <param name="directory">Название папки вида "directory"</param>
    public static void MoveTo(string directory)
    {
        if (_fullPath == "/")
        {
            _fullPath += directory;
            return;
        }
        
        _fullPath += "/" + directory;
    }

    /// <summary>
    /// Покинуть директорию
    /// Подняться на папку выше относительно текущей директории
    /// /home/user/path/dir -> /home/user/path
    /// </summary>
    public static void Leave()
    {
        int newPathLength = _fullPath.Split('/').Length - 1;
        string[] folders = new string[newPathLength];

        for (int i = 0; i < newPathLength; i++)
        {
            folders[i] = _fullPath.Split('/')[i];
        }

        Clear();

        for (int i = 1; i < newPathLength; i++)
        {
            _fullPath += "/" + folders[i];
        }
    }

    public static void Show()
    {
        string[] output = new string[3]
        {
            "╔════════════════════════════════════════════════════╗",
            "║                                                    ║",
            "╚════════════════════════════════════════════════════╝"
        };

        output[1] = "║ " + fullPath;

        for (int i = 0; i < output[0].Length - fullPath.Length - 3; i++)
        {
            output[1] += " ";
        }

        output[1] += "║";

        foreach (string line in output)
        {
            Console.WriteLine(line);
        }
    }
}