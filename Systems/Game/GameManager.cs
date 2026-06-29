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
    public void Start()
    {
        int menuOption = ShowInitialMenu();
        if (menuOption == -1)
        {
            return;
        }

        Heroe hero = LoadOrCreateHero(menuOption);

        _shopMenu.Open(hero);

        _inventoryMenu.Open(hero);

        ShowHeroInfo(hero);

        Enemy enemy = EnemyFactory.CreateRandomEnemy();

        ShowEnemyInfo(enemy);

        _combatSystem.StartBattle(
            hero,
            enemy
        );
    }
}