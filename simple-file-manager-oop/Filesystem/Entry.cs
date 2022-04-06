namespace simple_file_manager_oop.Filesystem;

public abstract class Entry
{
    private string _path;
    private string _name;

    protected string Path
    {
        get => _path;
        set => _path = value;
    }
    
    protected string Name
    {
        get => _name;
        set => _name = value;
    }
    
    protected Entry(string path, string name)
    {
        _path = path;
        _name = name;
    }
    
    public abstract void Delete();

    public void Rename(string name)
    {
        _name = name;
    }

    public abstract void Copy(string path);
}