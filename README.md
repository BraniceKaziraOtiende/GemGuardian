markdown# Gem Guardian  
**A 2D Top-Down Unity Game Demonstrating OOP & Design Patterns**  
**Author**: Branice Kazira Otiende  
**Course**: Object-Oriented Programming with Unity  
**Submission Date**: November 10, 2025  

---

## Game Overview  
**Gem Guardian** is a fast-paced 2D top-down action game where the player must collect **20 glowing gems** while surviving endless waves of enemy intruders.  
- **Controls**: WASD to move, **SPACE** to jump  
- **Goal**: Collect 20 gems → **Victory!**  
- **Threats**: 5 unique enemy types with different AI behaviors  
- **Polish**: SFX, UI feedback, Win/Lose screens, restart functionality  

---

## Core Features  
- Smooth physics-based movement with gravity  
- Modular player system (Movement, Health, Collision)  
- 5 enemy types with unique AI (Patrol, Chase, Dive, Charge)  
- Collectible gems with score tracking ("x20")  
- Wave spawning every 10 seconds  
- Win condition (20 gems) + Game Over  
- Professional UI: Main Menu, Win/Lose panels with **Restart** and **Main Menu** buttons  

---

## OOP Principles Implemented  

| Principle       | Implementation |
|-----------------|----------------|
| **Encapsulation** | `PlayerHealth.health` is private → only modified via `TakeDamage()` |
| **Abstraction**   | `ICollectible` interface → Gem, Cherry, SpeedBoost all work the same |
| **Inheritance**   | `BearEnemy`, `DogEnemy` → inherit from `Enemy` base class |
| **Polymorphism**  | `Strategy.Execute()` → same call, 5 different AI behaviors |

---

## Design Patterns (All Creational!)  

| Pattern     | Where Used | Why It’s Perfect |
|-------------|-----------|------------------|
| **Singleton** | `GameManager`, `EnemyFactory` | Global access, no duplicates |
| **Factory**   | `EnemyFactory.SpawnRandomEnemy()` | Centralized, extensible enemy creation |
| **Builder**   | Step-by-step enemy construction in Factory | Same process → different final enemies |

> **Builder Pattern Insight**: While not a full `EnemyBuilder` class, the factory **builds** each enemy in phases: instantiate → set speed → assign strategy → initialize health. This **pipeline** is a real-world, practical use of Builder.

---

## Project Structure
Assets/
├── Scripts/
│   ├── Players/        → PlayerMovement, PlayerHealth, PlayerCollision
│   ├── Enemies/        → Enemy.cs + 5 child classes
│   ├── Patterns/       → IEnemyStrategy, Patrol/Chase/DiveStrategy
│   ├── Managers/       → GameManager, EnemyFactory
│   ├── Collectibles/   → Gem.cs, Cherry.cs, ICollectible
│   └── UI/             → EndGameUI.cs
├── Scenes/
│   ├── MainMenu.unity
│   └── GameScene.unity
├── Prefabs/
│   ├── Player.prefab
│   └── Enemies/ (5 prefabs)
└── UI/
└── Canvas + Panels
text---

## Setup Instructions  
1. Clone the repo:  
   ```bash
   git clone https://github.com/BraniceKaziraOtiende/GemGuardian.git

Open in Unity 2022.3+
Open Scenes/GameScene
Press Play → Enjoy!


Assets Used

Free 2D Platformer Pack (Unity Asset Store)
Pixel UI Pack (for buttons & panels)
Free Game SFX Pack (collect sound)


