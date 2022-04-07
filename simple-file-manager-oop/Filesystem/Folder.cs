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
    /// Copy Folder
    /// </summary>
    /// <param name="path"></param>
    public override void Copy(string path)
    {
        
    }
    
    /// <summary>
    /// Copy Folder with override
    /// </summary>
    /// <param name="path"></param>
    /// <param name="overrideFolder"></param>
    public override void Copy(string path, bool overrideFolder)
    {
        
    }
}