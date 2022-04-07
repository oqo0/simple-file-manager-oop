namespace simple_file_manager_oop.Filesystem;

public class Folder : Entry
{
    public Folder(string path, string name) : base(path, name) {}
    
    /// <summary>
    /// Create a new directory
    /// </summary>
    /// <param name="path">path whre to create</param>
    /// <param name="name">name of a new dir</param>
    public static void Create(string path, string name)
    {
        try
        {
            Directory.CreateDirectory(path + name);
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
}