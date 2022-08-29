using System.Diagnostics;
using System.Linq;

namespace MineSweeperLogic;

public interface IGame
{
    Stopwatch Stopwatch { get; set; }
    Board Board { get; set; }
    GameState GameState { get; set; }

    void LeftClicked(int x, int y);
    void MiddleClicked(int x, int y);
    void MineClicked(object? sender, EventArgs e);
    void RightClicked(int x, int y);
    void WinCheck();
}

public class Game : IGame
{
    public Stopwatch Stopwatch { get; set; } = new Stopwatch();

    public Board Board { get; set; }
    public GameState GameState { get; set; } = GameState.Playing;

    public Game(int Width, int Height, int MineCount)
    {
        Board = new Board(Width, Height, MineCount);
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


