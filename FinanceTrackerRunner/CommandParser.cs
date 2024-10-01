namespace FinanceTrackerRunner;

interface ICommandParser
{
    string RecognizeCommand(string command);
}
public class CommandParser: ICommandParser
{
    public string RecognizeCommand(string command)
    {
        
        if (command.StartsWith("add money"))
        {
            return "gainMoney"; 
        } 
        if (command.StartsWith("spend money"))
        {
            return "spendMoney";
        }
        if (command.StartsWith("info"))
        {
            return "info";
        }

        if (command.StartsWith("exit"))
        {
            return "end";
        }

        return "";
    }
}