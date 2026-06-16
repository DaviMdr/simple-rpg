using System.Text.Json;
using RPG_Simplificado.Characters.Heroes;

namespace RPG_Simplificado.Save;

public static class SaveManager
{
    private const string SavePath = "Saves/savegame.json";

    public static void SaveGame(Heroe hero)
    {
        Directory.CreateDirectory("Saves");

        SaveData data = new()
        {
            Class = hero.GetType().Name,
            Name = hero.Name,
            HP = hero.HP,
            Attack = hero.Attack,
            Defense = hero.Defense,
            Level = hero.Level,
            Experience = hero.Experience,
            Inventory = hero.Inventory
        };

        string json =
            JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        File.WriteAllText(SavePath, json);
    }

    public static bool SaveExists()
    {
        return File.Exists(SavePath);
    }

    public static SaveData LoadData()
    {
        string json =
            File.ReadAllText(SavePath);

        return JsonSerializer.Deserialize<SaveData>(json)!;
    }
}