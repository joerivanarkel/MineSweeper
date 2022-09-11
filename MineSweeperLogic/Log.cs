namespace MineSweeperLogic;

public class Log
{
    public string? Message { get; set; }
    public DateTime DateAndTime { get; set; } = DateTime.Now;

    public int Seconds { get; set; }

    public Coordinate Coordinate  { get; set; }
}