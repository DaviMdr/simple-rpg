# RPG Simplificado

## Descrição

RPG Simplificado é um jogo de batalha por turnos desenvolvido em **C#** utilizando os principais conceitos de **Programação Orientada a Objetos (POO)**.

O jogador escolhe uma classe de herói, enfrenta inimigos aleatórios, ganha experiência, sobe de nível, utiliza poções durante o combate e pode salvar seu progresso para continuar jogando posteriormente.

---

## Objetivos do Projeto

- Aplicar conceitos de Programação Orientada a Objetos.
- Implementar um sistema de combate por turnos.
- Trabalhar com herança e polimorfismo.
- Utilizar coleções para gerenciamento de inventário.
- Implementar persistência de dados através de arquivos JSON.
- Aplicar tratamento de exceções.

---

## Tecnologias Utilizadas

- C#
- .NET Console Application
- System.Text.Json

---

## Estrutura do Projeto

```text
RPG Simplificado
│
├── Program.cs
│
├── Characters
│   ├── Character.cs
│   │
│   ├── Heroes
│   │   ├── Heroe.cs
│   │   ├── Warrior.cs
│   │   ├── Wizard.cs
│   │   └── Archer.cs
│   │
│   └── Enemies
│       ├── Enemy.cs
│       ├── Goblin.cs
│       ├── Orc.cs
│       └── Dragon.cs
│
├── Combat
│   └── CombatSystem.cs
│
├── Items
│   ├── Item.cs
│   └── Potion.cs
│
├── Interfaces
│   └── IUsable.cs
│
├── Save
│   ├── SaveData.cs
│   └── SaveManager.cs
│
├── Utils
│   └── Dice.cs
│
└── Saves
    └── savegame.json
```

---

## Classes Jogáveis

### Guerreiro

- HP: 120
- Ataque: 20
- Defesa: 10

**Habilidade Especial**

```text
Ataque × 2
```

---

### Mago

- HP: 80
- Ataque: 25
- Defesa: 4

**Habilidade Especial**

```text
Ataque + 20
```

---

### Arqueiro

- HP: 90
- Ataque: 18
- Defesa: 6

**Habilidade Especial**

```text
Ataque + 10
```

---

## Inimigos

| Inimigo | HP  | Ataque | Defesa | XP  |
| ------- | --- | ------ | ------ | --- |
| Goblin  | 40  | 10     | 3      | 25  |
| Orc     | 70  | 15     | 6      | 50  |
| Dragão  | 150 | 30     | 15     | 150 |

Os inimigos são escolhidos aleatoriamente ao iniciar uma batalha.

---

## ⚔️ Sistema de Combate

O combate ocorre em turnos.

Em cada turno o jogador pode escolher:

```text
1 - Ataque Normal
2 - Habilidade Especial
3 - Usar Poção
```

Após a ação do jogador, o inimigo realiza seu ataque.

O combate termina quando:

```text
HP do Herói <= 0
```

ou

```text
HP do Inimigo <= 0
```

---

## Sistema de Dano

O dano possui uma pequena variação aleatória utilizando a classe estática `Dice`.

Exemplo:

```csharp
Dice.Roll(
    hero.Attack - 5,
    hero.Attack
);
```

O dano final considera a defesa do alvo.

```csharp
finalDamage = damage - Defense;
```

---

## Sistema de Inventário

Cada herói possui um inventário baseado em:

```csharp
List<Potion>
```

Poções disponíveis:

### Poção Pequena

```text
+20 HP
```

### Poção Grande

```text
+50 HP
```

As poções podem ser utilizadas durante o combate consumindo o turno do jogador.

---

## Sistema de Experiência

Ao derrotar um inimigo o jogador recebe experiência.

Exemplo:

```text
Goblin → 25 XP
Orc → 50 XP
Dragão → 150 XP
```

---

## 📈 Sistema de Nível

Ao atingir 100 pontos de experiência:

```text
Level + 1
```

O personagem recebe:

```text
HP + 20
Ataque + 5
Defesa + 2
```

O sistema preserva o XP excedente.

Exemplo:

```text
XP Atual = 80
XP Ganho = 50

XP Total = 130

Level Up

XP Restante = 30
```

---

## Sistema de Save e Load

O projeto salva automaticamente o progresso do jogador em um arquivo JSON.

Arquivo gerado:

```text
Saves/savegame.json
```

Ao iniciar o jogo:

```text
1 - Novo Jogo
2 - Continuar
```

### Novo Jogo

Cria um novo personagem.

### Continuar

Carrega o último save existente.

---

## Conceitos de POO Aplicados

### Encapsulamento

Utilização de propriedades para acesso aos atributos.

```csharp
public string Name { get; set; }
public int HP { get; set; }
```

---

### Herança

```text
Character
│
├── Heroe
│   ├── Warrior
│   ├── Wizard
│   └── Archer
│
└── Enemy
    ├── Goblin
    ├── Orc
    └── Dragon
```

---

### Polimorfismo

Método abstrato:

```csharp
public abstract int SpecialAttack();
```

Cada herói implementa sua própria versão da habilidade especial.

---

### Classes Abstratas

Classes utilizadas:

```text
Character
Heroe
Enemy
```

Essas classes servem como base para outras classes e não podem ser instanciadas diretamente.

---

### Coleções

Utilização de:

```csharp
List<Potion>
```

para gerenciamento do inventário.

---

### Tratamento de Exceções

Utilização de blocos `try-catch` para evitar falhas por entradas inválidas do usuário.

```csharp
try
{
    int option = int.Parse(Console.ReadLine()!);
}
catch
{
    Console.WriteLine("Opção inválida.");
}
```

---

### Métodos Estáticos

Classe utilitária:

```csharp
Dice.Roll()
```

Responsável pela geração dos valores aleatórios dos ataques.

---

## Como Executar

Clone o repositório:

```bash
git clone <url-do-repositorio>
```

Entre na pasta do projeto:

```bash
cd RPG-Simplificado
```

Execute:

```bash
dotnet run
```

---

## 🔮 Melhorias Futuras

- Sistema de equipamentos
- Loja de itens
- Múltiplos combates consecutivos
- Sistema de missões
- Chefes especiais
- Sistema de habilidades evolutivas
- Mapa explorável
- Interface gráfica (Windows Forms ou WPF)
- Banco de dados para saves
- Sistema de raridade de itens

---

## Conceitos Demonstrados

Classes e Objetos

Encapsulamento

Construtores

Herança

Polimorfismo

Classes Abstratas

Coleções

Tratamento de Exceções

Métodos Estáticos

Serialização JSON

Persistência de Dados

---

## Autor

Projeto desenvolvido para fins acadêmicos com foco na aplicação dos conceitos de Programação Orientada a Objetos utilizando C#.
