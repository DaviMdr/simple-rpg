namespace RPG_Simplificado.Finance;

public class Wallet
{
    public decimal Balance { get; private set; }

    public List<Transaction> Transactions { get; set; }

    public Wallet()
    {
        Balance = 0;
        Transactions = new List<Transaction>();
    }

    private void AddTransaction(
        string type,
        decimal amount,
        string description)
    {
        Transaction transaction =
            new Transaction(
                amount,
                type,
                description
            );

        Transactions.Add(transaction);
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException(
                "O valor do depósito deve ser maior que zero");

        Balance += amount;

        AddTransaction(
            "DEPOSITO",
            amount,
            "Depósito realizado"
        );
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException(
                "O valor do saque deve ser maior que zero");

        if (Balance < amount)
            throw new InvalidOperationException(
                "Saldo insuficiente."
            );

        Balance -= amount;

        AddTransaction(
            "SAQUE",
            amount,
            "Saque realizado"
        );
    }

    public void ShowTransactions()
    {
        foreach (Transaction transaction in Transactions)
        {
            Console.WriteLine(
                $"{transaction.Date:dd/MM/yyyy HH:mm} | " +
                $"{transaction.Type} | " +
                $"{transaction.Amount:C}"
            );

            Console.WriteLine(
                $"Descrição: {transaction.Description}"
            );

            Console.WriteLine();
        }
    }
    public void RestoreBalance(decimal balance)
    {
        Balance = balance;
    }
}
