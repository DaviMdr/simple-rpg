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
}
