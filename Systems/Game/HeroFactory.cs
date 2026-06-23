using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Items;
using RPG_Simplificado.Save;

namespace RPG_Simplificado.Systems.Game;

public static class HeroFactory
{
    public static Heroe CreateNewHero()
    {
        Console.WriteLine("\nEscolha sua classe:");
        Console.WriteLine("1 - Guerreiro");
        Console.WriteLine("2 - Mago");
        Console.WriteLine("3 - Arqueiro");

        int option;

        try
        {
            option = int.Parse(Console.ReadLine()!);
        }
        catch
        {
            Console.WriteLine("Opção inválida.");
            throw;
        }

        Console.Write("Digite o nome do personagem: ");
        string name = Console.ReadLine()!;

        Heroe hero;

        switch (option)
        {
            case 1:
                hero = new Warrior(name);
                break;

            case 2:
                hero = new Wizard(name);
                break;

            case 3:
                hero = new Archer(name);
                break;

            default:
                hero = new Warrior(name);
                break;
        }

        hero.Inventory.Add(
            new Potion(
                "Poção Pequena",
                "Recupera 20 HP",
                10,
                20
            )
        );

        hero.Inventory.Add(
            new Potion(
                "Poção Grande",
                "Recupera 50 HP",
                25,
                50
            )
        );

        return hero;
    }

    public static Heroe LoadHero(SaveData data)
    {
        Heroe hero;

        switch (data.Class)
        {
            case "Warrior":
                hero = new Warrior(data.Name);
                break;

            case "Wizard":
                hero = new Wizard(data.Name);
                break;

            case "Archer":
                hero = new Archer(data.Name);
                break;

            default:
                hero = new Warrior(data.Name);
                break;
        }

        hero.RestoreStats(
            data.HP,
            data.Attack,
            data.Defense,
            data.Level,
            data.Experience,
            data.Gold
        );

        foreach (var item in data.Inventory)
        {
            hero.Inventory.Add(item);
        }

        return hero;
    }
}