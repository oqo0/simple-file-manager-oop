using System;

namespace simple_file_manager_oop
{
    class FileManager
    {
        public static void Main()
        {
            Console.WriteLine("══════════════════════════════════════════════════════".Length);
            Path.MoveTo("home/oqo0/Desktop");
            Path.Show();
            
            Folder currentFolder = new Folder("current");
            currentFolder.ShowContainedFolders();
            currentFolder.ShowContainedFiles();
        }
    }
}