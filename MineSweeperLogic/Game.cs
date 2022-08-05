namespace MineSweeperLogic;

public class Game
{
    public Board Board { get; set; }
    public bool GameState {get; set;}

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

    public void MineClicked(object sender, EventArgs e)
    {
        GameState = false;
    }
}
