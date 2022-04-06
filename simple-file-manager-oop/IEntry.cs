namespace simple_file_manager_oop;

public interface IEntry
{
    void Create(string name);
    void Delete();
    void Rename(string name);
    void Copy(string path);
}