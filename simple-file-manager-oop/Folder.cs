namespace simple_file_manager_oop;

public class Folder : IEntry
{
    private string _path;
    private string _name;
    
    public string Path
    {
        get
        {
            return _path;
        }
    }
    
    public Folder(string name)
    {
        this._name = name;
    }
    
    public void Create(string name)
    {
        Directory.CreateDirectory(simple_file_manager_oop.Path.fullPath + "/" + name);
    }

    public void Delete()
    {
        
    }

    public void Rename(string name)
    {
        
    }

    public void Copy(string path)
    {
        
    }

    public void Search()
    {
        
    }

    public void ShowContainedFiles()
    {
        List<File> files = new List<File>();

        foreach (string f in Directory.GetFiles(_path))
        {
            files.Add(new File(f.Split('/').Last()));
        }
        
        foreach (var file in files)
        {
            Console.WriteLine($"{file.Name, 30} | {file.GetSizeSimplified(), 0}");
        }
        
        Console.WriteLine("══════════════════════════════════════════════════════");
    }

    public void ShowContainedFolders()
    {
        List<Folder> folders = new List<Folder>();
        
        foreach (string f in Directory.GetDirectories(_path))
        {
            folders.Add(new Folder(f.Split('/').Last()));
        }
        
        foreach (var folder in folders)
        {
            Console.WriteLine($"{folder.Path, 30}");
        }
        
        Console.WriteLine("══════════════════════════════════════════════════════");
    }
}