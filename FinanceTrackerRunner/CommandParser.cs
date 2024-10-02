interface ICommandParser
{
    string RecognizeCommand(string command);
}
public class CommandParser : ICommandParser
{
    public string RecognizeCommand(string command)
    {

        if (command.StartsWith("add money"))
        {
            return "add_money";
        }

        if (command.StartsWith("add account"))
        {
            return "add_account";
        }
        if (command.StartsWith("spend money"))
        {
            return "spend";
        }
        if (command.StartsWith("info accounts"))
        {
            return "info_accounts";
        }
        if (command.StartsWith("info transaction"))
        {
            return "info_transactions";
        }
        if (command.StartsWith("exit"))
        {
            return "end";
        }

        return "";
    }

    public List<String> getCommandArgs(String command)
    {
        string[] commandArgs = command.Split(' ');
        List<String> commandArgsList = commandArgs.ToList();

        return commandArgsList;
    }
}