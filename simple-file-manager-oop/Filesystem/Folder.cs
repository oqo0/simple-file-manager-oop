namespace simple_file_manager_oop.Filesystem;

public class Folder : Entry
{
    public Folder(string path) : base(path) {}
    
    /// <summary>
    /// Create a new directory
    /// </summary>
    /// <param name="path">path whre to create</param>
    public static void Create(string path)
    {
        try
        {
            Directory.CreateDirectory(path);
        }
        catch
        {
            Logger.Log($"Could not create a folder {path}");
        }
    }
    
    /// <summary>
    /// Delete directory
    /// </summary>
    public override void Delete()
    {
        try
        {
            Directory.Delete(base.Path, true);
        }
        catch
        {
            Logger.Log($"Could not delete a folder {base.Path}");
        }
    }

    /// <summary>
    /// Copy Folder with override
    /// </summary>
    /// <param name="destPath"></param>
    /// <param name="overrideFile"></param>
    public override void Copy(string destPath, bool overrideFile)
    {
        try
        {
            if (!Directory.Exists(base.Path))
            {
                Logger.Log("Could not copy a folder. Source folder does not exist.");
                return;
            }
            
            // Create a dir where we are going to copy files
            Directory.CreateDirectory(destPath);
            
            // Copy each file
            foreach (var file in Directory.GetFiles(base.Path))
            {
                System.IO.File.Copy(base.Path, destPath, overrideFile);
            }

            // Copy each folder (recursive)
            foreach (var dir in Directory.GetDirectories(base.Path))
            {
                Copy(destPath, overrideFile);
            }
        }
        catch
        {
            Logger.Log($"Could not copy folder.");
        }
    }

    public void ShowDirs()
    {
        string[] dirs = Directory.GetDirectories(Path);

        foreach (string dir in dirs)
        {
            Console.WriteLine(dir);
        }
    }

    public void ShowFiles()
    {
        string[] files = Directory.GetFiles(Path);

        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
    }
}