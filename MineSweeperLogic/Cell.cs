namespace MineSweeperLogic;

public class Cell
{
    public CellState CellState { get; set; }
    public MineState MineState{get; set;}
    public event EventHandler? MineClicked;
    public int Value { get; set; } 

    private readonly ILogger _logger;

    public Cell(ILogger logger)
    {
        _logger = logger;
    }

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
        {
            CellState = CellState.Revealed;
        }

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
        switch (CellState)
        {
            case CellState.Hidden:
                return "/Images/Hidden.png";
            case CellState.Flagged:
                return "/Images/Flagged.png";
            case CellState.Revealed:
                switch (MineState)
                {
                    case MineState.Mine:
                        return "/Images/Mine.png";
                    case MineState.Empty:
                        return "/Images/Revealed.png";
                    case MineState.BordersMine:
                        return $"/Images/{Value}.png";
                    default:
                        return "/Images/MineUnclicked.png";
                }
            default:
                return "/Images/MineUnclicked.png";
        }
    }
}
