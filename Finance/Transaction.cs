namespace RPG_Simplificado.Finance;

public class Transaction
{
    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public Transaction(
        decimal amount,
        string type,
        string description)
    {
        Date = DateTime.Now;
        Amount = amount;
        Type = type;
        Description = description;
    }
}