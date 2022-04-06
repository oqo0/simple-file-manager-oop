using System.IO;

namespace simple_file_manager_oop;

public class File : IEntry
{
    private string _path = Path.fullPath;
    private string _name;
    
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
    public long GetSize(UnitsOfData dataUnit)
    {
        long fileSize = new FileInfo(_path + _name).Length;
        
        switch (dataUnit)
        {
            case UnitsOfData.Byte:
            {
                return fileSize;
                break;
            }
            case UnitsOfData.Kilobyte:
            {
                return 1024 * fileSize;
                break;
            }
            case UnitsOfData.Megabyte:
            {
                return 1024 * 1024 * fileSize;
                break;
            }
            default:
            {
                return 0;
                break;
            }
        }
    }
}