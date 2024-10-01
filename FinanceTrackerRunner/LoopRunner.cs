namespace FinanceTrackerRunner;
using DB;
using Accounts;
public interface ILoopRunner
{
    void RunLoop();
    CommandParser Parser { get; }
}
public class LoopRunner:ILoopRunner
{ 
    public CommandParser Parser { get; } = new CommandParser();
    public void RunLoop() 
    {
        AccountsOrganizer organizer = new AccountsOrganizer();
        organizer.LoadAccounts();
        Account currentAccount = organizer.GetAccount("JohnDoe");
        while (true) 
        {
            string command = Parser.RecognizeCommand(Console.ReadLine());
            switch (command) 
            {
                case "gainMoney": 
                    currentAccount.AddMoney(99.0);
                    currentAccount.AddTransaction(new Transaction(99.0, "MyAcc", "Money to me", new DateTime(2025, 01, 01)));
                    organizer.SaveAccounts();
                    break;
        
                case "s":
                    break;
            } 
            if (command == "exit")
            {
                break;
            }
        }
       
    }
}