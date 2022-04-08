using FileManagerLibrary.FileSystem;
using FileManagerLibrary.ConsoleOutput;

namespace simple_file_manager_oop
{
    class FileManager
    {
        public static void Main()
        {
            PathEntry path = new PathEntry("/");

            while (true)
            {
                Output.ShowPath(path);
                Output.ShowDirs(path);
                Output.ShowFiles(path);
                
                CommandHandler.Perform(ref path);
                
                Console.Clear();
            }
        }
    }
}