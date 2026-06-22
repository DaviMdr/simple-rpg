using RPG_Simplificado.Characters.Heroes;

namespace RPG_Simplificado.Systems.Shop;

public class ShopMenu
{
    private readonly Merchant _merchant;

    public ShopMenu()
    {
        _merchant = new Merchant();
    }

    public void Open(Heroe heroe)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== LOJA ===");

            Console.WriteLine(
                $"Saldo: {heroe.Wallet.Balance} moedas"
            );

            Console.WriteLine();

            _merchant.ShowProducts();

            Console.WriteLine();
            Console.WriteLine("0 - Sair");

            Console.WriteLine();
            Console.Write("Escolha: ");

            int option;

            try
            {
                option = int.Parse(
                    Console.ReadLine()!
                );
            }
            catch
            {
                Console.WriteLine(
                    "Opção inválida."
                );

                Console.ReadKey();
                continue;
            }

            if (option == 0)
            {
                running = false;
                continue;
            }

            _merchant.BuyItem(
                heroe,
                option - 1
            );

            Console.WriteLine();
            Console.WriteLine(
                "Pressione qualquer tecla..."
            );

            Console.ReadKey();
        }
    }
}