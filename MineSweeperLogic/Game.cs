using System.Diagnostics;

namespace MineSweeperLogic;

public class Game : IGame
{
    public Stopwatch Stopwatch { get; set; } = new Stopwatch();

    public Board Board { get; set; }

    public GameState GameState { get; set; } = GameState.Playing;

    public List<( string UserName,int Score)> HighScore { get; set; } = new List<(string UserName, int Score)>();

    public int Height { get; set; } = 50;

    public int Width { get; set; } = 20;

    public int AmountOfMines { get; set; }= 10;

    public MineSweeperLogic.ILogger Logger {get;set;}

    public string UserName { get; set; }

    public Game(ILogger logger)
    {    
        Logger = logger;
    }

    public void Start()
    {
        GameState = GameState.Playing;
        Stopwatch = new Stopwatch();
        Board = new Board(Width, Height, AmountOfMines, Logger);
        Board.BoardMineClickedEvent += MineClicked;
        Stopwatch.Start();
        Logger.Start();
    }
    
    public void LeftClicked(int x, int y)
    {
        
        Logger.Log(x, y, Stopwatch.Elapsed.Seconds, $"Left clicked");
        Board.LeftClicked(x, y);
    }

    public void RightClicked(int x, int y)
    {
        Logger.Log(x,y, Stopwatch.Elapsed.Seconds, "Right clicked");
        Board.RightClicked(x, y);
    }

    public void MiddleClicked(int x, int y)
    {
        Logger.Log(x,y, Stopwatch.Elapsed.Seconds, "Middle clicked");
        Board.MiddleClicked(x, y);
    }

    public void MineClicked(object? sender, EventArgs e)
    {
        GameState = GameState.Lost;
        Stopwatch.Stop();
    }

    public void WinCheck(int x, int y)
    {
        if (CheckCells())
        {
            Logger.Log(x,y, Stopwatch.Elapsed.Seconds, "Game won");
            GameState = GameState.Win;
            Stopwatch.Stop();
        }
    }

    private bool CheckCells()
    {
        var foundCells = from Cell cell in Board.Cells
                         where (cell.CellState == CellState.Flagged || cell.CellState == CellState.Hidden)
                         && cell.MineState != MineState.Mine
                         select cell;
        return foundCells.Count() == 0;
    }

    public void SaveScore()
    {
        HighScore.Add((UserName, Stopwatch.Elapsed.Seconds));
    }
}


