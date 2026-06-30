# Arquitetura

O projeto foi dividido em módulos independentes.

## Characters

Responsável por representar todas as entidades vivas.

```
Character
│
├── Heroe
│    ├── Warrior
│    ├── Wizard
│    └── Archer
│
└── Enemy
     ├── Goblin
     ├── Orc
     └── Dragon
```

---

## Combat

Responsável pelo combate entre personagens.

```
CombatSystem
```

---

## Systems

Responsável pelos sistemas do jogo.

```
Game
Shop
Inventory
Equipment
```

Cada sistema possui apenas uma responsabilidade.

---

## Items

Todos os itens do jogo.

```
Item
│
├── Potion
├── Weapon
└── Armor
```

Potion implementa:

```
IUsable
```

Weapon e Armor implementam:

```
IEquippable
```

---

## Save

Responsável pela persistência.

Atualmente utiliza JSON.

Planejamento:

JSON → SQLite
