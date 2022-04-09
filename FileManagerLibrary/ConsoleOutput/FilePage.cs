namespace FileManagerLibrary.ConsoleOutput;

public class FilePage
{
    private int _index = 1;

    public int Index
    {
        get => _index;
        set
        {
            if (value >= 1)
                _index = value;
        }
    }
}