namespace MineSweeperLogic;

public class Logger : ILogger
{
    public List<Log> Logs { get; set; } = new List<Log>();
    public void Log(string message)
    {
        Logs.Add(new Log() { Message = message });
    }
}
