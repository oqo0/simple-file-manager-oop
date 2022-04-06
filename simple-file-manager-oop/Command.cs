namespace simple_file_manager_oop;

public class Command
{
    private static List<string> commandHistory = new List<string>();
    
    private string _command;
    private string[] _commandArgs;
    
    public Command(string commandText)
    {
        this._command = commandText;
        this._commandArgs = commandText.Split(' ');
        
        commandHistory.Add(this._command);
    }

    public void Execute()
    {
        switch (_commandArgs[0].ToLower())
        {
            case ("cd"):
            {
                
                break;
            }
            case ("copy"):
            {
                
                break;
            }
            case ("paste"):
            {
                
                break;
            }
        }
    }
}