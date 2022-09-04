using System.Diagnostics;

namespace MineSweeperLogic;

public class Game : IGame
{
    public Stopwatch Stopwatch { get; set; } = new Stopwatch();

    public Board Board { get; set; }

    public GameState GameState { get; set; } = GameState.Playing;

    public int Height { get; set; } = 50;

    public int Width { get; set; } = 20;

    public int AmountOfMines { get; set; }= 10;



    public Game(){    
    }

    public void Start()
    {
        GameState = GameState.Playing;
        Stopwatch = new Stopwatch();
        Board = new Board(Width, Height, AmountOfMines);
        Board.BoardMineClickedEvent += MineClicked;
        Stopwatch.Start();
    }
    

    public void LeftClicked(int x, int y)
    {
        Board.LeftClicked(x, y);
    }

    public void RightClicked(int x, int y)
    {
        Board.RightClicked(x, y);
    }

    public void MiddleClicked(int x, int y)
    {
        Board.MiddleClicked(x, y);
    }

    public void MineClicked(object? sender, EventArgs e)
    {
        GameState = GameState.Lost;
        Stopwatch.Stop();
    }

    public void WinCheck()
    {
        if (CheckCells())
        {
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
}


