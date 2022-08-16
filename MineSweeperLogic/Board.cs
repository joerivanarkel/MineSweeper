namespace MineSweeperLogic;
public class Board
{
    private int Width { get; set; }
    private int Height { get; set; }
    private int MineCount { get; set; }
    public Cell[,] Cells { get; set; }
    private List<Mine> Mines { get; set; } = new List<Mine>();

    public event EventHandler BoardMineClickedEvent;

    public Board(int width, int height, int mineCount)
    {
        DetermineMineCells(mineCount, width, height);
        Cells = new Cell[width, height];
        Width = width;
        Height = height;
        MineCount = mineCount;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                MineState mineState = MineState.Empty;
                if (Mines.Where(a => a.X == x && a.Y == y).Count() > 0)
                {
                    mineState = MineState.Mine;
                }

                var cell = new Cell() { MineState = mineState };
                cell.MineClicked += MineClicked;
                Cells[x, y] = cell;
            }
        }
        DetermineMineBorders();
    }

    public void DetermineMineBorders()
    {
        try
        {
            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    if (Cells[x, y].MineState == MineState.Mine)
                    {
                        var maxX = Cells.GetLength(0) - 1;
                        var maxY = Cells.GetLength(1) - 1;

                        var startX = x - 1 <= 0 ? 0 : x - 1;
                        var endX = x + 1 >= maxX ? maxX : x + 1;
                        for (int i = startX; i <= endX; i++)
                        {
                            var startY = y - 1 <= 0 ? 0 : y - 1;
                            var endY = y + 1 >= maxY ? maxY : y + 1;
                            for (int z = startY; z <= endY; z++)
                            {
                                var foundCell = Cells[i, z];
                                if (foundCell.MineState != MineState.Mine)
                                {
                                    foundCell.MineState = MineState.BordersMine;
                                    foundCell.Value += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (System.Exception exception)
        {
            Console.WriteLine(exception.ToString());
        }
    }
    public void LeftClicked(int x, int y)
    {
        try
        {
            var clickedCell = Cells[x, y];
            if (clickedCell.MineState == MineState.BordersMine && clickedCell.CellState != CellState.Revealed)
            {
                clickedCell.LeftClick();
                return;
            }
            if(clickedCell.CellState == CellState.Revealed) { return; }
            if(clickedCell.CellState == CellState.Flagged) { return; }

            var maxX = Cells.GetLength(0) -1;
            var maxY = Cells.GetLength(1) -1;

            var startX = x - 1 <= 0 ? 0 : x - 1;
            var endX = x + 1 >= maxX ? maxX : x + 1;

            for (int i = startX; i <= endX; i++)
            {
                var startY = y - 1 <= 0 ? 0 : y - 1;
                var endY = y + 1 >= maxY ? maxY : y + 1;
                for (int z = startY; z <= endY; z++)
                {
                    var foundCell = Cells[i, z];
                    if (z == y && i == x)
                    {
                        foundCell.LeftClick();
                    }
                    if (foundCell.MineState == MineState.BordersMine && foundCell.CellState != CellState.Revealed)
                    {
                        foundCell.Reveal();
                    }
                    if (foundCell.MineState == MineState.Empty && foundCell.CellState != CellState.Revealed)
                    {
                        foundCell.Reveal();
                        ChainReveal(i, z);
                    }
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine( exception.ToString());
        }

    }

    public void ChainReveal(int x, int y)
    {
        try
        {
            var maxX = Cells.GetLength(0) - 1;
            var maxY = Cells.GetLength(1) - 1;

            var startX = x - 1 <= 0 ? 0 : x - 1;
            var endX = x + 1 >= maxX ? maxX : x + 1;

            for (int i = startX; i <= endX; i++)
            {
                var startY = y - 1 <= 0 ? 0 : y - 1;
                var endY = y + 1 >= maxY ? maxY : y + 1;
                for (int z = startY; z <= endY; z++)
                {
                    var foundCell = Cells[i, z];
                    if (foundCell.MineState == MineState.BordersMine && foundCell.CellState != CellState.Revealed)
                    {
                        foundCell.Reveal();
                    }
                    if (foundCell.MineState == MineState.Empty && foundCell.CellState != CellState.Revealed)
                    {
                        foundCell.Reveal();
                        ChainReveal(i, z);
                    }
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.ToString());
        }
    }

    public void RightClicked(int x, int y)
    {
        var foundCell = Cells[x, y];
        if (foundCell.CellState == CellState.Revealed){ return; }
        Cells[x, y].RightClick();
    }

    public void MineClicked(object? sender, EventArgs e)
    {
        BoardMineClickedEvent.Invoke(sender, e);
    }

    private void DetermineMineCells(int mineCount, int width, int height)
    {
        for (int i = 0; i < mineCount; i++)
        {
            var x = new Random().Next(width);
            var y = new Random().Next(height);
            Mines.Add(new Mine() { X = x, Y = y });
        }
    }
}

