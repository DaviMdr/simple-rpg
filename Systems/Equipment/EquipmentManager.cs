using RPG_Simplificado.Items;
using RPG_Simplificado.Characters.Heroes;

namespace RPG_Simplificado.Systems.Equipment;

public class EquipmentManager
{
    public void EquipWeapon(
        Heroe hero,
        Weapon weapon)
    {
        Weapon? oldWeapon = hero.EquippedWeapon;

        if (oldWeapon != null)
        {
            hero.Inventory.Add(oldWeapon);
        }

        hero.Inventory.Remove(weapon);

        hero.EquippedWeapon = weapon;

        Console.WriteLine(
        $"{hero.Name} equipou {weapon.Name}."
        );
    }

    public void EquipArmor(
        Heroe hero,
        Armor armor)
    {
        Armor? oldArmor = hero.EquippedArmor;

        if (oldArmor != null)
        {
            hero.Inventory.Add(oldArmor);
        }

        hero.Inventory.Remove(armor);

        hero.EquippedArmor = armor;

        Console.WriteLine(
        $"{hero.Name} equipou {armor.Name}."
        );
    }
}