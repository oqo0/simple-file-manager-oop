namespace simple_file_manager_oop.Filesystem;

public abstract class Entry
{
    private PathBuilder _path;
    private string _name;

    protected string Path
    {
        get
        {
            return _path.path;
        }
        set
        {
            PathBuilder p = new PathBuilder();
            p.path = value;
            _path = p;
        }
    }
    
    protected string Name
    {
        get => _name;
        set => _name = value;
    }
    
    protected Entry(string path) : this(path, "none") { }
    protected Entry(string path, string name)
    {
        Path = path;
        Name = name;
    }
    
    public abstract void Delete();

    public void Rename(string name)
    {
        _name = name;
    }
    
    public abstract void Copy(string path, bool overwriteFile);
}