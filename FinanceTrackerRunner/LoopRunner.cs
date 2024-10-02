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

            string command = Parser.RecognizeCommand(userInput);
            var argsList = Parser.getCommandArgs(userInput);

            if (command == "add_money")
            {
                //field validation needs to be added here

                String transactionType = argsList[0];
                Double amount = double.Parse(argsList[2]);
                String accountName = argsList[3];
                String comment = argsList[4];

                currentAccount.AddMoney(amount);
                currentAccount.AddTransaction(new Transaction(transactionType, amount, accountName, comment, new DateTime(2024, 02, 01)));
                Organizer.SaveAccounts();
                //code for saving transactions will be moved to the end of the if statement
                //to not duplicate code. Operation specific logic will be handled here
            }
            else if (command == "add_account")
            {
                Currency currency=(Currency)Enum.Parse(typeof(Currency), argsList[2]);
                String accountName=argsList[3];
                Account newAccount=new Account(accountName, 0,  currency);
                Organizer.AddAccount(newAccount);
                Organizer.SaveAccounts();
            }
            else if (command == "spend")
            {
                //field validation needs to be added here

                String transactionType = argsList[0];
                Double amount = double.Parse(argsList[2]);
                String accountName = argsList[3];
                String comment = argsList[4];

                currentAccount.TakeMoney(amount);
                currentAccount.AddTransaction(new Transaction(transactionType, amount, accountName, comment, new DateTime(2024, 02, 01)));
                Organizer.SaveAccounts();
            }
            else if(command == "info_transactions")
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
            else if (command == "info_accounts")
            {
                foreach (var account in Organizer.Accounts)
                {
                    Console.WriteLine($"Account Name: {account.Name}, Balance: {account.Money}, Currency: {account.Currency}");
                }
            }
            else if (command == "end")
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