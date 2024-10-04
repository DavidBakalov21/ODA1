using Accounts;
using System.IO;
namespace FinanceTrackerRunner;


public interface ICommandExecutor
{
    public void InfoAccounts();
    public void InfoTransactions();
    public void Spend(Account currentAccount, List<String> argsList);
    public void AddAccount(List<String> argsList);
    public void AddMoney(Account currentAccount, List<String> argsList);

    public void SetOrganizer(AccountsOrganizer organizer);

}
public class CommandExecutor: ICommandExecutor
{
    private AccountsOrganizer Organizer;

    public void SetOrganizer(AccountsOrganizer organizer)
    {
        Organizer = organizer;
    }

    public void InfoAccounts()
    {
        foreach (var account in Organizer.Accounts)
        {
            Console.WriteLine($"Account Name: {account.Name}, Balance: {account.Money}, Currency: {account.Currency}");
        }
    }

    public void InfoTransactions()
    {
        foreach (var account in Organizer.Accounts)
        {
            Console.WriteLine($"Account Name: {account.Name}");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine($"Transaction: {transaction.Quantity} {transaction.Comment} on {transaction.Date}, Account:{transaction.AccountName}");
            }
        }
    }

    public void Spend(Account currentAccount, List<String> argsList)
    {
        //field validation needs to be added here
        String transactionType = argsList[0];
        Double amount = double.Parse(argsList[2]);
        String accountName = argsList[3];
        String comment = argsList[4];
        try
        {
            Organizer.GetAccount(accountName).TakeMoney(amount);
        }
        catch (Exception e)
        {
            Console.WriteLine("Impossible.");
        } 

        //currentAccount.TakeMoney(amount);
        currentAccount.AddTransaction(new Transaction(transactionType, amount, accountName, comment, new DateTime(2024, 02, 01)));
        Organizer.SaveAccounts();
    }

    public void AddAccount(List<String> argsList)
    {
        Currency currency=(Currency)Enum.Parse(typeof(Currency), argsList[2]);
        String accountName=argsList[3];
        Account newAccount=new Account(accountName, 0,  currency);
        Organizer.AddAccount(newAccount);
        Organizer.SaveAccounts();
    }

    public void ExportTransactions()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("exportFile.txt"))
            {
                foreach (var account in Organizer.Accounts)
                {
                    writer.WriteLine($"Account Name: {account.Name}");
                
                    foreach (var transaction in account.Transactions)
                    {
                        writer.WriteLine($"Transaction: {transaction.Quantity} {transaction.Comment} on {transaction.Date}, Account: {transaction.AccountName}");
                    }

                    writer.WriteLine(); // Adds an empty line between accounts
                }
            }

            Console.WriteLine("Data successfully written to exportFile.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
        }
    }
    public void AddMoney(Account currentAccount, List<String> argsList)
    {
        //field validation needs to be added here
        String transactionType = argsList[0];
        Double amount = double.Parse(argsList[2]);
        String accountName = argsList[3];
        String comment = argsList[4];
        try
        {
            Organizer.GetAccount(accountName).AddMoney(amount);
        } catch (Exception e)
        {
            Console.WriteLine("Impossible.");
        } 
        //currentAccount.AddMoney(amount);
        currentAccount.AddTransaction(new Transaction(transactionType, amount, accountName, comment, new DateTime(2024, 02, 01)));
        Organizer.SaveAccounts();
        //code for saving transactions will be moved to the end of the if statement
        //to not duplicate code. Operation specific logic will be handled here
    }
}