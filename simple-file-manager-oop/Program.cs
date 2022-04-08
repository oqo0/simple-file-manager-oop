using FileManagerLibrary.FileSystem;
using FileManagerLibrary.ConsoleOutput;

namespace simple_file_manager_oop
{
    class FileManager
    {
        public static void Main()
        {
            PathEntry path = new PathEntry("/");
            
            Output.ShowDirsTree(path, 0);
            Console.WriteLine("---------------------------------------------------------------------");
            Output.ShowFiles(path);

            Console.ReadLine();
        }
    }
}