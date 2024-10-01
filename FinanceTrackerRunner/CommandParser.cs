namespace FinanceTrackerRunner;

interface ICommandParser
{
    string RecognizeCommand(string command);
}
public class CommandParser: ICommandParser
{
    public string RecognizeCommand(string command)
    {
        if (command=="money")
        {
            return "gainMoney"; 
        }
        else
        {
            return "exit";
        }
      
    }
}