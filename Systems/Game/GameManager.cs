using RPG_Simplificado.Characters.Enemies;
using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Combat;
using RPG_Simplificado.Save;
using RPG_Simplificado.Systems.Shop;

namespace RPG_Simplificado.Systems.Game;

public class GameManager
{
    public void Start()
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
            return;
        }

        Heroe hero;

        if (
            menuOption == 2 &&
            SaveManager.SaveExists()
        )
        {
            SaveData data =
                SaveManager.LoadData();

            hero =
                HeroFactory.LoadHero(data);

            Console.WriteLine(
                "\nSave carregado com sucesso!"
            );
        }
        else
        {
            hero =
                HeroFactory.CreateNewHero();
        }

        hero.Wallet.Deposit(100);

        ShopMenu shopMenu =
            new ShopMenu();

        shopMenu.Open(hero);

        Enemy enemy =
            EnemyFactory.CreateRandomEnemy();

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

        Console.WriteLine(
            $"Inimigo: {enemy.Name}"
        );

        Console.WriteLine();
        Console.WriteLine(
            "Combate iniciado!"
        );

        CombatSystem combat =
            new CombatSystem();

        combat.StartBattle(
            hero,
            enemy
        );
    }
}