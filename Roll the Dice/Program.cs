namespace RollTheDice;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        new Game(rounds: 10).Play();
    }
}

public class Dice
{
    private readonly Random _random;
    public Dice(Random random) => _random = random;
    public int Roll() => _random.Next(1, 7);
}

public static class DiceRenderer
{
    private static readonly Dictionary<int, string[]> Faces = new()
    {
        [1] = new[] { "┌─────┐", "│     │", "│  ●  │", "│     │", "└─────┘" },
        [2] = new[] { "┌─────┐", "│ ●   │", "│     │", "│   ● │", "└─────┘" },
        [3] = new[] { "┌─────┐", "│ ●   │", "│  ●  │", "│   ● │", "└─────┘" },
        [4] = new[] { "┌─────┐", "│ ● ● │", "│     │", "│ ● ● │", "└─────┘" },
        [5] = new[] { "┌─────┐", "│ ● ● │", "│  ●  │", "│ ● ● │", "└─────┘" },
        [6] = new[] { "┌─────┐", "│ ● ● │", "│ ● ● │", "│ ● ● │", "└─────┘" },
    };

    public static void Animate(int finalPlayerValue)
    {
        var random = new Random();
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"\r  Rolling... {random.Next(1, 7)}  ");
            Thread.Sleep(80);
        }
        Console.Write($"\r  Rolling... {finalPlayerValue}  ");
        Thread.Sleep(1000);
        Console.WriteLine();
    }

    public static void Draw(int playerValue, int enemyValue)
    {
        var playerFace = Faces[playerValue];
        var enemyFace = Faces[enemyValue];

        Console.WriteLine("      You             Enemy");
        for (int line = 0; line < 5; line++)
            Console.WriteLine($"   {playerFace[line]}       {enemyFace[line]}");
    }
}

public class Player
{
    public string Name { get; }
    public int Score { get; private set; }
    public Player(string name) => Name = name;
    public void AddPoint() => Score++;
}

public class Game
{
    private readonly Dice _dice;
    private readonly Player _player;
    private readonly Player _enemy;
    private readonly int _rounds;

    public Game(int rounds = 10)
    {
        _dice = new Dice(new Random());
        _player = new Player("You");
        _enemy = new Player("Enemy");
        _rounds = rounds;
    }

    public void Play()
    {
        ShowWelcomeMessage();

        for (int round = 1; round <= _rounds; round++)
            PlayRound(round);

        AnnounceWinner();
    }
    private void ShowWelcomeMessage()
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine("The rules are simple: roll the dice and hope for the best.");
        Console.WriteLine("Let's get started.\n");
        Console.WriteLine("Press any key to enter the game...");
        Console.ReadKey(true);
    }

    private void PlayRound(int round)
    {
        Console.WriteLine($"\n--- Round {round}/{_rounds} ---");
        Console.WriteLine("Press any key to roll the dice...");
        Console.ReadKey(true);

        int playerRoll = _dice.Roll();
        int enemyRoll = _dice.Roll();

        DiceRenderer.Animate(playerRoll);
        DiceRenderer.Draw(playerRoll, enemyRoll);

        if (playerRoll > enemyRoll) { _player.AddPoint(); Print("You win this round!", ConsoleColor.Green); }
        else if (playerRoll < enemyRoll) { _enemy.AddPoint(); Print("Enemy wins this round!", ConsoleColor.Red); }
        else Print("It's a tie!", ConsoleColor.Yellow);

        Console.WriteLine($"Score — You: {_player.Score} | Enemy: {_enemy.Score}");
    }

    private void AnnounceWinner()
    {
        Console.WriteLine("\n=== GAME OVER ===");
        if (_player.Score > _enemy.Score) Print("🏆 You won the game!", ConsoleColor.Green);
        else if (_player.Score < _enemy.Score) Print("💀 Enemy won the game!", ConsoleColor.Red);
        else Print("It's an overall tie!", ConsoleColor.Yellow);
    }

    private static void Print(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}