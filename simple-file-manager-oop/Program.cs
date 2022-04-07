using System;
using simple_file_manager_oop.Filesystem;
using File = simple_file_manager_oop.Filesystem.File;

namespace simple_file_manager_oop
{
    class FileManager
    {
        public static void Main()
        {
            Folder folder = new Folder("/");
            
            folder.ShowDirs();
            
            Console.ReadKey();
        }
    }
}