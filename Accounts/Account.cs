namespace Accounts;

public interface IAccount {
    String Name {get; set;}
    Double Money {get; set;}
    Currency Currency {get; set;}
    List<Transaction> Transactions {get; set;}
    void AddMoney(Double money);
    void TakeMoney(Double money);
    void AddTransaction(Transaction transaction);
    void ExchangeCurrency(Currency targetCurrency);
    
}

public class Account: IAccount {
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
    
    public void ExchangeCurrency(Currency targetCurrency)
    {
        if (Currency == targetCurrency)
        {
            Console.WriteLine($"Converted to {targetCurrency}. New balance: {Money} {targetCurrency}");
            return;
        }

        double conversionRate = GetConversionRate(targetCurrency);
        Money = conversionRate*Money;
        Currency = targetCurrency;

        Console.WriteLine($"Converted to {targetCurrency}. New balance: {Money} {targetCurrency}");
    }

    private double GetConversionRate(Currency toCurrency)
    {
        if (Currency == Currency.USD && toCurrency == Currency.UAH)
            return 36.75;
        if (Currency == Currency.USD && toCurrency == Currency.EUR)
            return 0.85;
        if (Currency == Currency.UAH && toCurrency == Currency.USD)
            return 0.027;
        if (Currency == Currency.UAH && toCurrency == Currency.EUR)
            return 0.023;
        if (Currency == Currency.EUR && toCurrency == Currency.USD)
            return 1.18;
        if (Currency == Currency.EUR && toCurrency == Currency.UAH)
            return 43.50;
        
        return 1.0;
    }
}