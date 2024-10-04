namespace FinanceTrackerRunner;
using Accounts;
public interface ILoopRunner
{
    void RunLoop();
    AccountsOrganizer Organizer { get; }
    CommandParser Parser { get; }
}
public class LoopRunner:ILoopRunner
{
    public AccountsOrganizer Organizer { get; }
    private CommandExecutor Executor { get; }
    public LoopRunner(AccountsOrganizer accountsOrganizer)
    {
        Organizer = accountsOrganizer;
        Executor = new CommandExecutor(); 
        Executor.SetOrganizer(accountsOrganizer);
    }
    
    public CommandParser Parser { get; } = new CommandParser();
    public void RunLoop() 
    {
        String userInput = "";
        Organizer.LoadAccounts();

        Console.WriteLine("Enter account name: ");
        userInput = Console.ReadLine();

        Account currentAccount = Organizer.GetAccount(userInput);
        if (currentAccount == null)
        {
            currentAccount = new Account(userInput, 0, Currency.USD);
            Organizer.AddAccount(currentAccount);
            Organizer.SaveAccounts();
        }
        Console.WriteLine($"\nLogged in {currentAccount.Name}\n");

        while (true) 
        {
            Console.WriteLine("Enter a command: ");
            userInput = Console.ReadLine();
            
            var argsList = Parser.getCommandArgs(userInput);

            if (userInput.StartsWith("add money"))
            {
                Executor.AddMoney(currentAccount, argsList);
            }
            else if (userInput.StartsWith("add account"))
            {
                Executor.AddAccount(argsList);
            }
            else if (userInput.StartsWith("spend money"))
            {
                Executor.Spend(currentAccount, argsList);
            }
            else if(userInput.StartsWith("info transaction"))
            {
                Executor.InfoTransactions();
            }
            else if (userInput.StartsWith("info accounts"))
            {
                Executor.InfoAccounts();
            }
            else if (userInput.StartsWith("export transactions"))
            {
                Executor.ExportTransactions();
            }
            else if (userInput.StartsWith("exit"))
            {
                Console.WriteLine("Are you sure you want to exit? (y/n): ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "y")
                {
                    break;
                }
            }
        }
       
    }

}