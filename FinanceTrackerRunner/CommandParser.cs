interface ICommandParser
{
    List<String> getCommandArgs(String command);
}
public class CommandParser : ICommandParser
{
    public List<String> getCommandArgs(String command)
    {
        string[] commandArgs = command.Split(' ');
        List<String> commandArgsList = commandArgs.ToList();

        return commandArgsList;
    }
}