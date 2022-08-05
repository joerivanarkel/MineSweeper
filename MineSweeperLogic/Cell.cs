namespace MineSweeperLogic;

public class Cell
{
    public CellState CellState { get; set; }

    public MineState MineState{get; set;}
    public event EventHandler MineClicked;

    public int Value { get; set; } 

    public Cell()
    {
    }
    
    public bool IsMine { get; set; }
    public bool IsEmpty { get; set; }
    public bool HaveMineAsNeighbour { get; set; }

    public void LeftClick()
    {
        if(IsMine) MineClicked.Invoke(this, null);
        CellState = CellState.Revealed;

    }

    public void Reveal()
    {
        if(!IsMine)
            CellState = CellState.Revealed;
    }

    public void RightClick()
    {
        CellState = CellState.Flagged;
    }
}
