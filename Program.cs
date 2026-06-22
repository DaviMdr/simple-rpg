using RPG_Simplificado.Characters.Enemies;
using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Combat;
using RPG_Simplificado.Items;
using RPG_Simplificado.Save;
using RPG_Simplificado.Systems.Shop;

Console.WriteLine("=== RPG Simplificado ===");

Console.WriteLine("1 - Novo Jogo");
Console.WriteLine("2 - Continuar");

int menuOption;

try
{
    menuOption = int.Parse(Console.ReadLine()!);
}
catch
{
    Console.WriteLine("Opção inválida.");
    return;
}

Heroe hero;

if (menuOption == 2 && SaveManager.SaveExists())
{
    SaveData data = SaveManager.LoadData();

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
        data.Gold);

    foreach (var potion in data.Inventory)
    {
        hero.Inventory.Add(potion);
    }

    Console.WriteLine(
        $"\nSave carregado com sucesso!"
    );
}
else
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
        return;
    }

    Console.Write("Digite o nome do personagem: ");
    string name = Console.ReadLine()!;

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
            20)
    );

    hero.Inventory.Add(
        new Potion(
            "Poção Grande",
            "Recupera 50 HP",
            25,
            50
        )
    );
}

Merchant merchant = new Merchant();

merchant.ShowProducts();

Random random = new Random();

Enemy enemy;

switch (random.Next(3))
{
    case 0:
        enemy = new Goblin();
        break;

    case 1:
        enemy = new Orc();
        break;

    default:
        enemy = new Dragon();
        break;
}

Console.WriteLine();
Console.WriteLine($"Herói: {hero.Name}");
Console.WriteLine($"Nível: {hero.Level}");
Console.WriteLine($"XP: {hero.Experience}");
Console.WriteLine($"Inimigo: {enemy.Name}");

Console.WriteLine();
Console.WriteLine("Combate iniciado!");

CombatSystem combat = new CombatSystem();
combat.StartBattle(hero, enemy);