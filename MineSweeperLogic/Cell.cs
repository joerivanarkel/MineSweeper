namespace MineSweeperLogic;

public class Cell
{
    public CellState CellState { get; set; }
    public MineState MineState{get; set;}
    public event EventHandler? MineClicked;

    public int Value { get; set; } 

    public void LeftClick()
    {
        CellState = CellState.Revealed;
        if(MineState == MineState.Mine)
        {
            if(MineClicked != null)
            {
                MineClicked.Invoke(this, new EventArgs()); 
            }
        } 
    }
    public void Reveal()
    {
        if (MineState != MineState.Mine)
            CellState = CellState.Revealed;
    }

    public void RightClick()
    {
        CellState = CellState.Flagged;
    }
}
