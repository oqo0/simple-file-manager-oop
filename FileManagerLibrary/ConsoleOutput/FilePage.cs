namespace FileManagerLibrary.ConsoleOutput;

public class FilePage
{
    private int _index = 1;

    public int Index
    {
        get
        {
            return _index;
        }
        private set
        {
            if (value >= 1)
            {
                _index = value;
            }
        }
    }

    public void OpenPrevious()
    {
        Index -= 1;
    }
    
    public void OpenNext()
    {
        Index += 1;
    }
}