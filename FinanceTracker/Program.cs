// See https://aka.ms/new-console-template for more information

using DB;
using Accounts;
using FinanceTrackerRunner;
//DB works fine
//Account organizer wroks fine
class Program
{
    static void Main(string[] args)
    {
        
        AccountsOrganizer organizer = new AccountsOrganizer(new FileAccountStorage("tasks.txt"));
      
       LoopRunner runner = new LoopRunner(organizer);
       runner.RunLoop();
    }
    
}