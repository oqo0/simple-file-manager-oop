using System.IO;

namespace simple_file_manager_oop;

public class File : IEntry
{
    private string _path;
    private string _name;

    public File(string name)
    {
        _path = Path.fullPath;
        _name = name;
    }
    
    public void Create(string name)
    {
        
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

    /// <summary>
    /// Размер файла
    /// </summary>
    /// <returns></returns>
    public long GetSize()
    {
        return new FileInfo(_path + _name).Length;
    }

    /// <summary>
    /// Размер файла в нужном формате
    /// </summary>
    /// <returns></returns>
    public string GetSizeSimplified()
    {
        long fileSize = new FileInfo(_path + "/" + _name).Length;
        
        switch (fileSize)
        {
            case >= 1024 * 1024 * 1024:
                return Convert.ToString(fileSize / 1024 / 1024 / 1024) + "gb";
            case >= 1024 * 1024:
                return Convert.ToString(fileSize / 1024 / 1024) + "mb";
            case >= 1024:
                return Convert.ToString(fileSize / 1024) + "kb";
            default:
                return Convert.ToString(fileSize) + "b";
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }
}