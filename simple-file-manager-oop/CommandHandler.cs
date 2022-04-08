using FileManagerLibrary.FileSystem;

namespace simple_file_manager_oop;

public static class CommandHandler
{
    /// <summary>
    /// Прочитать и выполнить команду
    /// </summary>
    public static void Perform(ref PathEntry path)
    {
        Console.Write("Enter command > ");
        string command = Console.ReadLine();
        Execute(command, ref path);
        Console.WriteLine();
    }
    
    private static void Execute(string text, ref PathEntry path)
    {
        string[] commandArgs = text.Split(' ');

        switch (commandArgs[0])
        {
            case "cd":
            {
                path.Open(commandArgs[1]);
                break;
            }

            case "ld":
            {
                path.GoUp();
                break;
            }

            case "kd":
            {
                path.Clear();
                break;
            }
        }
    }
}