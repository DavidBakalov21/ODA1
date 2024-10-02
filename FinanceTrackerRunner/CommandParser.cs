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
            return "add";
        }
        if (command.StartsWith("spend money"))
        {
            return "spend";
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

    public List<String> getCommandArgs(String command)
    {
        string[] commandArgs = command.Split(' ');
        List<String> commandArgsList = commandArgs.ToList();

        return commandArgsList;
    }
}