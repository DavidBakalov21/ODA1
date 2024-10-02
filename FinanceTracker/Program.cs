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
        
       
     //   Console.WriteLine("Hello World!"); 
        //AccountsOrganizer organizer = new AccountsOrganizer();
        
        //Account johnDoe = new Account("Acc1", 10000, Currency.USD);
        //johnDoe.addTransaction(new Transaction(200, "n", "Groceries", new DateTime(2024, 01, 01)));
        //johnDoe.addTransaction(new Transaction(300, "m", "Rent", new DateTime(2024, 02, 01)));
        
       // organizer.addAccount(johnDoe);
       
        //organizer.SaveAccounts();
        /*
        organizer2.LoadAccounts();
        foreach (var account in organizer2.Accounts)
        {
            Console.WriteLine($"Account Name: {account.Name}, Balance: {account.Money}, Currency: {account.Currency}");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine($"Transaction: {transaction.Quantity} {transaction.Comment} on {transaction.Date}, Account:{transaction.AccountName}");
            }
        }
        */
    }
    
}