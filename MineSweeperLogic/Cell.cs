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
        if(CellState != CellState.Flagged)
            CellState = CellState.Flagged;
        else
            CellState = CellState.Hidden;
    }

    public string GetImageName()
    {
        if (CellState == CellState.Hidden)
        {
            return "/Images/Hidden.png";
        }
        if (CellState == CellState.Flagged)
        {
            return "/Images/Flagged.png";
        }
        if (CellState == CellState.Revealed)
        {
            if (MineState == MineState.Mine)
            {
                return "/Images/Mine.png";
            }
            if (MineState == MineState.Empty)
            {
                return "/Images/Revealed.png";
            }
            if (MineState == MineState.BordersMine)
            {
                return $"/Images/{Value}.png";
            }
        }
        return "/Images/MineUnclicked.png"; 
    }
}
