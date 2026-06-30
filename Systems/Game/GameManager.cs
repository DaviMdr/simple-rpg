using RPG_Simplificado.Characters.Enemies;
using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Combat;
using RPG_Simplificado.Save;
using RPG_Simplificado.Systems.Shop;
using RPG_Simplificado.Systems.Inventory;

namespace RPG_Simplificado.Systems.Game;

public class GameManager
{
    private readonly ShopMenu _shopMenu;
    private readonly InventoryMenu _inventoryMenu;
    private readonly CombatSystem _combatSystem;



    public void Start()
    {
        int menuOption = ShowInitialMenu();
        if (menuOption == -1)
        {
            return;
        }

        Heroe heroe = LoadOrCreateHero(menuOption);

        MainLoop(heroe);
    }

    private int ShowInitialMenu()
    {
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
            return -1;
        }

        return menuOption;
    }

    private Heroe LoadOrCreateHero(int menuOption)
    {
        if (menuOption == 2 && SaveManager.SaveExists())
        {
            SaveData data = SaveManager.LoadData();

            Heroe heroe = HeroFactory.LoadHero(data);

            Console.WriteLine(
                "\nSave carregado com sucesso!"
            );

            return heroe;
        }

        return HeroFactory.CreateNewHero();
    }

    private void MainLoop(Heroe heroe)
    {
        bool running = true;

        while (running)
        {
            int option = ShowCityMenu();

            if (option == -1)
            {
                continue;
            }

            running = ExecuteOption(
                option,
                heroe
            );
        }
    }

    private int ShowCityMenu()
    {
        Console.WriteLine("\n=== CIDADE ===");

        Console.WriteLine("1 - Explorar");
        Console.WriteLine("2 - Loja");
        Console.WriteLine("3 - Inventário");
        Console.WriteLine("4 - Status");
        Console.WriteLine("0 - Sair");

        Console.Write("\nEscolha: ");

        int option;

        try
        {
            option = int.Parse(Console.ReadLine()!);
        }
        catch
        {
            Console.WriteLine("Opcao inválida.");
            return -1;
        }

        return option;
    }


    private bool ExecuteOption(
        int option,
        Heroe heroe)
    {
        switch (option)
        {
            case 1:
                Explore(heroe);
                return true;

            case 2:
                _shopMenu.Open(heroe);
                return true;

            case 3:
                _inventoryMenu.Open(heroe);
                return true;

            case 4:
                ShowHeroInfo(heroe);
                return true;

            case 0:
                return false;

            default:
                Console.WriteLine("Opção inválida.");
                return true;
        }
    }

    private void Explore(Heroe hero)
    {
        Enemy enemy = EnemyFactory.CreateRandomEnemy();

        ShowEnemyInfo(enemy);

        _combatSystem.StartBattle(
            hero,
            enemy
        );
    }

    private void ShowHeroInfo(Heroe hero)
    {
        Console.WriteLine();
        Console.WriteLine(
            $"Herói: {hero.Name}"
        );

        Console.WriteLine(
            $"Nível: {hero.Level}"
        );

        Console.WriteLine(
            $"XP: {hero.Experience}"
        );
    }

    private void ShowEnemyInfo(Enemy enemy)
    {
        Console.WriteLine(
            $"Inimigo: {enemy.Name}"
        );

        Console.WriteLine();
        Console.WriteLine(
            "Combate iniciado!"
        );
    }

    public GameManager()
    {
        _shopMenu = new ShopMenu();
        _inventoryMenu = new InventoryMenu();
        _combatSystem = new CombatSystem();
    }










}