using System.Diagnostics;

namespace MineSweeperLogic;

public interface IGame
{
    Stopwatch Stopwatch { get; set; }
    Board Board { get; set; }
    GameState GameState { get; set; }
    int Height { get; set; }

    int Width { get; set; }

    int AmountOfMines { get; set; }

    MineSweeperLogic.ILogger Logger {get;set;}



    void Start();
    void LeftClicked(int x, int y);
    void MiddleClicked(int x, int y);
    void MineClicked(object? sender, EventArgs e);
    void RightClicked(int x, int y);
    void WinCheck();
}


