using System.Diagnostics;

namespace MineSweeperLogic;

public interface IGame
{
    Stopwatch Stopwatch { get; set; }
    Board Board { get; set; }
    GameState GameState { get; set; }
    public int Height { get; set; }

    public int Width { get; set; }

    public int AmountOfMines { get; set; }


    void Start();
    void LeftClicked(int x, int y);
    void MiddleClicked(int x, int y);
    void MineClicked(object? sender, EventArgs e);
    void RightClicked(int x, int y);
    void WinCheck();
}


