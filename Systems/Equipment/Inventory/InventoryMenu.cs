using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Interfaces;
using RPG_Simplificado.Items;

namespace RPG_Simplificado.Systems.Inventory;

public class InventoryMenu
{
    public void Open(Heroe heroe)
    {
        if (heroe.Inventory.Count == 0)
        {
            Console.WriteLine("Inventário vazio.");
            return;
        }

        Console.WriteLine("\n=== INVENTÁRIO ===");

        for (int i = 0; i < heroe.Inventory.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1} - {heroe.Inventory[i].Name}"
            );
        }

        Console.WriteLine("\nEscolha um item:");

        int choice;

        try
        {
            choice = int.Parse(Console.ReadLine()!) - 1;
        }
        catch
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        if (choice < 0 || choice >= heroe.Inventory.Count)
        {
            Console.WriteLine("Item inválido.");
            return;
        }

        Item item = heroe.Inventory[choice];

        if (item is IEquippable equippable)
        {
            equippable.Equip(heroe);
            return;
        }

        if (item is IUsable usable)
        {
            usable.Use(heroe);

            Console.WriteLine(
                $"{heroe.Name} utilizou {item.Name}."
            );

            heroe.Inventory.Remove(item);
            return;
        }
    }
}