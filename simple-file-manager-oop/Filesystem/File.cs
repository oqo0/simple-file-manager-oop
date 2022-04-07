namespace simple_file_manager_oop.Filesystem;

public class File : Entry
{
    public File(string path, string name) : base(path, name) {}
    
    /// <summary>
    /// Create a new file
    /// </summary>
    /// <param name="path">path to a new file</param>
    /// <param name="name">name of a new file</param>
    public static void Create(string path, string name)
    {
        try
        {
            System.IO.File.Create(System.IO.Path.Combine(path, name));
        }
        catch
        {
            Logger.Log($"Could not create a file {path}");
        }
    }
    
    /// <summary>
    /// Delete file
    /// </summary>
    public override void Delete()
    {
        try
        {
            System.IO.File.Delete(System.IO.Path.Combine(base.Path, Name));
        }
        catch
        {
            Logger.Log($"Could not delete a file at {base.Path}");
        }
    }
    
    /// <summary>
    /// Copy File
    /// </summary>
    /// <param name="path"></param>
    public override void Copy(string path)
    {
        string copyFrom = System.IO.Path.Combine(base.Path, Name);
        string copyWhere = System.IO.Path.Combine(path, Name);
        
        System.IO.File.Copy(copyFrom, copyWhere);
    }
    
    /// <summary>
    /// Copy File with override
    /// </summary>
    /// <param name="path"></param>
    /// <param name="overrideFile"></param>
    public override void Copy(string path, bool overrideFile)
    {
        string copyFrom = System.IO.Path.Combine(base.Path, Name);
        string copyWhere = System.IO.Path.Combine(path, Name);
        
        System.IO.File.Copy(copyFrom, copyWhere, overrideFile);
    }
}