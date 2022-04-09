using FileManagerLibrary;
using FileManagerLibrary.ConsoleOutput;
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
        
        switch (commandArgs[0].ToLower())
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

            case "create":
            {
                if (commandArgs[1] == "folder")
                    Folder.Create(commandArgs[2]);

                if (commandArgs[1] == "file")
                    FileEntry.Create(commandArgs[2]);
                
                break;
            }

            case "delete":
            {
                if (commandArgs[1] == "folder")
                    Folder.Delete(commandArgs[2]);

                if (commandArgs[1] == "file")
                    FileEntry.Delete(commandArgs[2]);  
                
                break;
            }

            case "rename":
            {
                if (commandArgs[1] == "folder")
                    Folder.Rename(commandArgs[2], commandArgs[3]);

                if (commandArgs[1] == "file")
                    FileEntry.Rename(commandArgs[2], commandArgs[3]);
                
                break;
            }

            case "copy":
            {
                if (commandArgs[1] == "folder")
                    Folder.Copy(commandArgs[2], commandArgs[3]);

                if (commandArgs[1] == "file")
                    FileEntry.Copy(commandArgs[2], commandArgs[3]);
                
                break;
            }

            case "search":
            {
                Output.ShowSearchResult(commandArgs[1], commandArgs[2]);
                
                break;
            }

            case "page":
            {
                Output.Page.Index = int.Parse(commandArgs[1]);
                
                break;
            }
            
            case "attributes":
            {
                Enum.TryParse(commandArgs[2], out System.IO.FileAttributes fileAttributes);
                FileEntry.ChangeAttributes(commandArgs[1], fileAttributes);
                break;
            }
            
            case "quit":
            {
                Environment.Exit(0);
                break;
            }
        }
    }
}