using System.Linq;

namespace MineSweeperLogic;

public class Game
{
    public Board Board { get; set; }
    public GameState GameState {get; set;} = GameState.Playing;

    public Game(int width, int height, int mineCount)
    {
        Board = new Board(width, height, mineCount);
        Board.BoardMineClickedEvent+= MineClicked;
    }

    public void LeftClicked(int x, int y)
    {
        Board.LeftClicked(x, y);
    }
    
    public void RightClicked(int x, int y)
    {
        Board.RightClicked(x,y);
    }

    public void MineClicked(object? sender, EventArgs e)
    {
        GameState = GameState.Lost;
    }

    public void WinCheck()
    {
        if(CheckCells())
            GameState = GameState.Win;
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


