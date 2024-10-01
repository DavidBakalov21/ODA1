namespace Accounts;

public interface IAccount{
    String Name {get; set;}
    Double Money {get; set;}
    Currency Currency {get; set;}
    List<Transaction> Transactions {get; set;}
    void AddMoney(Double money);
    void TakeMoney(Double money);
    void AddTransaction(Transaction transaction);
}

public class Account: IAccount{
    public string Name { get; set; }
    public double Money { get; set; }
    public Currency Currency { get; set; }

    public List<Transaction> Transactions { get; set; }= new List<Transaction>();
    public Account(string name, double money, Currency currency)
    {
        Name = name;
        Money = money;
        Currency = currency;
    }

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }
    public void AddMoney(Double money){
        Money += money;
    }
    public void TakeMoney(Double money){
        Money -= money;
    }
}