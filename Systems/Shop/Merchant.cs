using RPG_Simplificado.Items;
using RPG_Simplificado.Characters.Heroes;

namespace RPG_Simplificado.Systems.Shop;

public class Merchant
{
    private List<Item> Catalog;
    public Merchant()
    {
        Catalog = new List<Item>();
        Catalog.Add(
            new Potion(
                "Pocao Pequena",
                "Recupera 20 HP",
                10,
                20
            )
        );

        Catalog.Add(
            new Potion(
               "Pocao Grande",
                "Recupera 50 HP",
                25,
                50
            )
        );

        Catalog.Add(
            new Weapon(
                "Espada de Ferro",
                "Uma espada básica",
                50,
                5
            )
        );

        Catalog.Add(
            new Weapon(
                "Machado de Guerra",
                "Ataque pesado",
                100,
                10
            )
        );

        Catalog.Add(
            new Weapon(
                "Cajado de Madeira",
                "Lanca magias poderosas",
                150,
                20
            )
        );

        Catalog.Add(
            new Weapon(
                "Arco encantado",
                "Ataque rapidos",
                75,
                10 * 2
            )
        );

        Catalog.Add(
            new Armor(
                "Armadura de Couro",
                "Proteção simples",
                40,
                3
            )
        );

        Catalog.Add(
            new Armor(
                "Armadura de Ferro",
                "Proteção avançada",
                80,
                6
            )
        );
    }

    public void ShowProducts()
    {
        Console.WriteLine("\n=== LOJA ===");

        for (int i = 0; i < Catalog.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1} - {Catalog[i].Name} | {Catalog[i].Price} moedas"
            );
        }
    }

    public Item GetItem(int index)
    {
        return Catalog[index];
    }

    public void BuyItem(
        Heroe heroe,
        int itemIndex)
    {
        if (
            itemIndex < 0 ||
            itemIndex >= Catalog.Count
        )
        {
            Console.WriteLine(
                "Item inexistente."
            );

            return;
        }

        Item item = Catalog[itemIndex];

        try
        {
            heroe.Wallet.Withdraw(
                item.Price
            );

            heroe.Inventory.Add(item);

            Console.WriteLine(
                $"{item.Name} comprado com sucesso."
            );

            Console.WriteLine(
                $"Saldo restante: {heroe.Wallet.Balance}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                ex.Message
            );
        }
    }
}
