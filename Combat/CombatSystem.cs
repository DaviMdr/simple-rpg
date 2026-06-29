using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Characters.Enemies;
using RPG_Simplificado.Utils;
using RPG_Simplificado.Save;
using RPG_Simplificado.Finance;
using RPG_Simplificado.Items;
using RPG_Simplificado.Systems.Inventory;

namespace RPG_Simplificado.Combat;

public class CombatSystem
{
    private readonly InventoryMenu _inventoryMenu;

    public CombatSystem()
    {
        _inventoryMenu = new InventoryMenu();
    }
    public void StartBattle(Heroe hero, Enemy enemy)
    {
        int turn = 1;

        while (hero.IsAlive() && enemy.IsAlive())
        {
            Console.WriteLine($"\n=== TURNO {turn} ===");

            PlayerTurn(hero, enemy);

            if (!enemy.IsAlive())
            {
                Console.WriteLine($"\n{enemy.Name} foi derrotado!");

                Console.WriteLine(
                    $"{hero.Name} ganhou {enemy.ExperienceReward} XP!"
                );

                hero.GainExperience(enemy.ExperienceReward);

                hero.Wallet.Deposit(enemy.GoldReward);

                SaveManager.SaveGame(hero);

                Console.WriteLine(
                    "Progresso salvo com sucesso!"
                );

                break;
            }

            EnemyTurn(hero, enemy);

            if (!hero.IsAlive())
            {
                Console.WriteLine($"\n{hero.Name} foi derrotado!");
                break;
            }

            ShowStatus(hero, enemy);

            turn++;
        }
    }

    private void PlayerTurn(Heroe hero, Enemy enemy)
    {
        Console.WriteLine("\n1 - Ataque Normal");
        Console.WriteLine("2 - Habilidade Especial");
        Console.WriteLine("3 - Inventário");

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

        switch (option)
        {
            case 1:
                {
                    int totalAttack = hero.GetTotalAttack();

                    int damage = Dice.Roll(
                        Math.Max(1, totalAttack - 5),
                        totalAttack
                    );

                    enemy.TakeDamage(damage);

                    Console.WriteLine(
                        $"{hero.Name} atacou {enemy.Name} causando {damage} de dano."
                    );

                    break;
                }

            case 2:
                {
                    int damage = hero.SpecialAttack();

                    enemy.TakeDamage(damage);

                    Console.WriteLine(
                        $"{hero.Name} usou sua habilidade especial causando {damage} de dano."
                    );

                    break;
                }

            case 3:
                {
                    _inventoryMenu.Open(hero);
                    break;
                }

            default:
                {
                    Console.WriteLine("Opção inválida.");
                    break;
                }
        }
    }

    private void EnemyTurn(Heroe hero, Enemy enemy)
    {
        int damage = Dice.Roll(
            Math.Max(1, enemy.Attack - 5),
            enemy.Attack
        );

        hero.TakeDamage(damage);

        Console.WriteLine(
            $"{enemy.Name} atacou {hero.Name} causando {damage} de dano."
        );
    }

    private void UsePotion(Heroe hero)
    {
        if (hero.Inventory.Count == 0)
        {
            Console.WriteLine("Você não possui itens.");
            return;
        }

        Console.WriteLine("\n=== INVENTÁRIO ===");

        for (int i = 0; i < hero.Inventory.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1} - {hero.Inventory[i].Name}"
            );
        }

        int choice;

        try
        {
            choice = int.Parse(Console.ReadLine()!) - 1;
        }
        catch
        {
            Console.WriteLine("Escolha inválida.");
            return;
        }

        if (choice < 0 || choice >= hero.Inventory.Count)
        {
            Console.WriteLine("Item inexistente.");
            return;
        }

        Item selectedItem = hero.Inventory[choice];

        if (selectedItem is Potion potion)
        {
            potion.Use(hero);

            Console.WriteLine(
                $"{hero.Name} utilizou {potion.Name}."
            );

            hero.Inventory.RemoveAt(choice);
        }
        else
        {
            Console.WriteLine(
                "Este item não pode ser utilizado."
            );
        }
    }

    private void ShowStatus(Heroe hero, Enemy enemy)
    {
        Console.WriteLine("\n===== STATUS =====");

        Console.WriteLine(
            $"{hero.Name} | HP: {hero.HP} | Nível: {hero.Level} | XP: {hero.Experience} | Ouro: {hero.Wallet.Balance}"
        );

        Console.WriteLine(
            $"Arma: {hero.EquippedWeapon?.Name ?? "Nenhuma"}"
        );

        Console.WriteLine(
            $"Armadura: {hero.EquippedArmor?.Name ?? "Nenhuma"}"
        );

        Console.WriteLine(
            $"ATK Total: {hero.GetTotalAttack()}"
        );

        Console.WriteLine(
            $"DEF Total: {hero.GetTotalDefense()}"
        );

        Console.WriteLine(
            $"{enemy.Name} | HP: {enemy.HP}"
        );
    }
}