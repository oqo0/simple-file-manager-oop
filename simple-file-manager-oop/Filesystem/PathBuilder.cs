using System.Linq;

namespace simple_file_manager_oop.Filesystem;

public class PathBuilder
{
    private string _path = "/";

    public string path
    {
        get => _path;
        set => _path = value;
    }

    /// <summary>
    /// Move one dir up
    /// </summary>
    public void MoveUp()
    {
        string[] newPath = path.Split('/');
        
        // Removing the last element from array
        Array.Resize(ref newPath, newPath.Length - 1);
    }

    /// <summary>
    /// Move one dir down
    /// </summary>
    public void MoveDown(string folder)
    {
        _path += folder + "/";
    }
}