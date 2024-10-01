namespace Accounts;

public interface ITransaction{
    Double Quantity { get; set; }

    String AccountName { get; set; }

    String Comment { get; set; }

    DateTime Date { get; set; }
}
public class Transaction: ITransaction{
    public Double Quantity { get; set; }
    public String AccountName { get; set; }
    public String Comment { get; set; }
    public DateTime Date { get; set; }
    public Transaction(double quantity, string accountName, string comment, DateTime date)
    {
        Quantity = quantity;
        AccountName = accountName;
        Comment = comment;
        Date = date;
    }
}