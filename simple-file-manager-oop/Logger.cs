using System.IO;

namespace simple_file_manager_oop;

public class Logger
{
    public static void Log(string text)
    {
        string logPrefix = $"[{DateTime.Now}] ";
        File.AppendAllText("log.txt", logPrefix + text + "\n");
    }
}