namespace Accounts;
public interface IAccountOrganizer{
    public void LoadAccounts();
    public void SaveAccounts();
    
    public void AddAccount(Account account);
    public Account GetAccount(String account);
}

public class AccountsOrganizer: IAccountOrganizer{

    private IAccountStorage storage;

    public AccountsOrganizer(IAccountStorage storage)
    {
        this.storage = storage;
    }
    public List<Account> Accounts = new List<Account>();

    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }

    public Account GetAccount(String name)
    {
        foreach (var account in Accounts)
        {
            if (account.Name == name)
            {
                return account;
            }
        }

        return null;
    }
    public void LoadAccounts()
    {
        List<String> rawAccounts = storage.Load();

        foreach (var rawAccount in rawAccounts)
        {
            var parts = rawAccount.Split(',');
            string name = parts[0];
            double money = Double.Parse(parts[1]);

            Currency currency = (Currency)Enum.Parse(typeof(Currency), parts[2]);

            var account = new Account(name, money, currency);
            for (int i = 3; i < parts.Length; i++) 
            {
                var transactionParts = parts[i].Split(';');

                String type = transactionParts[0];
                double quantity = Double.Parse(transactionParts[1]);
                string accountName = transactionParts[2];
                string comment = transactionParts[3];
                DateTime date = DateTime.Parse(transactionParts[4]);

                //Console.WriteLine($"Quantity: {quantity}, Account: {accountName}, Comment: {comment}, Date: {date}");
                var transaction = new Transaction(type, quantity, accountName, comment, date);
                account.AddTransaction(transaction);
            }

            AddAccount(account);
        }
    }

    public void SaveAccounts()
    {
        List<String> dataToSave = new List<String>();

        foreach (var account in Accounts)
        {
            string formattedAccount = $"{account.Name},{account.Money},{account.Currency}";
            foreach (var transaction in account.Transactions)
            {
                string formattedTransaction = $"{transaction.Type};{transaction.Quantity};{transaction.AccountName};{transaction.Comment};{transaction.Date}";
                formattedAccount += $",{formattedTransaction}";
            }
            dataToSave.Add(formattedAccount);
        }
        storage.Save(dataToSave);
    }

}