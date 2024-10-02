namespace Accounts;

public interface ITransaction {

    String Type { get; set; }
    Double Quantity { get; set; }

    String AccountName { get; set; }

    String Comment { get; set; }

    DateTime Date { get; set; }
}
public class Transaction: ITransaction {
    public String Type { get; set; }
    public Double Quantity { get; set; }
    public String AccountName { get; set; }
    public String Comment { get; set; }
    public DateTime Date { get; set; }
    public Transaction(String type, double quantity, string accountName, string comment, DateTime date)
    {
        Type = type;
        Quantity = quantity;
        AccountName = accountName;
        Comment = comment;
        Date = date;
    }
}