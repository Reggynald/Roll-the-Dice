# 🎲 Roll the Dice

A simple console-based dice game written in C#, where you compete against a computer-controlled opponent over 10 rounds.

![Roll the Dice demo](rtd-demo.gif)

## How it works

Each round, both you and the enemy roll a six-sided die. Whoever rolls higher wins the round and earns a point. After 10 rounds, the player with the most points wins the game.

## Features

- Turn-based dice rolling against a CPU opponent
- ASCII-art dice faces rendered directly in the console
- A short "rolling" animation before each result is revealed
- Colored console output to highlight round and game outcomes
- Clean object-oriented structure (`Dice`, `Player`, `Game`, `DiceRenderer`) instead of one big procedural script

## Tech stack

- C# / .NET
- Console application (no external libraries)

## Getting started

**Requirements:** [.NET SDK](https://dotnet.microsoft.com/download) installed.

```bash
git clone https://github.com/Reggynald/Roll-the-Dice.git
cd Roll-the-Dice/"Roll the Dice"
dotnet run

Alternatively, open Roll the Dice.sln in Visual Studio and press F5.
Project structure

Roll-the-Dice/
├── Roll the Dice.sln
└── Roll the Dice/
    ├── Program.cs        # Entry point
    ├── Dice.cs           # Dice rolling logic
    ├── Player.cs         # Player state (name, score)
    ├── DiceRenderer.cs   # Console rendering & animations
    └── Game.cs           # Game loop and round logic

What I learned / practiced

This project was a refactoring exercise: it started as a single Main method with all logic inline, and was restructured into separate classes with clear responsibilities (single responsibility principle), encapsulated state (private setters), and a simple rendering layer separated from game logic.
Roadmap

A second version, Roll the Dice: Race, is in progress — instead of a fixed number of rounds, players race to a target score, with random power-ups (double points, steal points, and more) triggered along the way.
