namespace MineSweeperLogic;

public class Logger : ILogger
{
    public int ClickCount { get; set; }
    public int Seconds { get; set; }

    public List<Log> Logs { get; set; } = new List<Log>();
    public void Log(int x, int y, int seconds, string message)
    {
        Logs.Add(new Log() { Message = message, Coordinate = new Coordinate(x,y), Seconds = seconds });
        ClickCount ++;
        Seconds = seconds;
    }

    public void Start()
    {
        Logs.Clear();
        ClickCount = 0;
        Seconds = 0;
    }
}
