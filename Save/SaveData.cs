using RPG_Simplificado.Items;

namespace RPG_Simplificado.Save;

public class SaveData
{
    public string Class { get; set; } = "";

    public string Name { get; set; } = "";

    public int HP { get; set; }

    public int Attack { get; set; }

    public int Defense { get; set; }

    public int Level { get; set; }

    public int Experience { get; set; }

    public decimal Gold { get; set; }

    public List<Potion> Inventory { get; set; } = new();
}