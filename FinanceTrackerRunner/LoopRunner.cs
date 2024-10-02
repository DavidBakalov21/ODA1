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
    
    public LoopRunner(AccountsOrganizer accountsOrganizer)
    {
        Organizer = accountsOrganizer;
    }
    
    public CommandParser Parser { get; } = new CommandParser();
    public void RunLoop() 
    {
      Organizer.LoadAccounts();
      if (Organizer == null)
      {
          Console.WriteLine("The variable is null.");
      }
      else
      {
          Console.WriteLine("Tfine");
      }
        Account currentAccount = Organizer.GetAccount("JohnDoe");
        while (true) 
        {
            string command = Parser.RecognizeCommand(Console.ReadLine());
            switch (command) 
            {
                case "gainMoney": 
                    Console.WriteLine("Hello World!"); 
                    currentAccount.AddMoney(991.0);
                    currentAccount.AddTransaction(new Transaction(199.0, "dfsv", "bdffb", new DateTime(2095, 01, 01)));
                    Organizer.SaveAccounts();
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