namespace MineSweeperLogic;

public interface ILogger
{
    int ClickCount { get; set; }
    int Seconds { get; set; }
    List<Log> Logs { get; set; }

    void Log(int x, int y, int seconds, string message);

    void Start();
}
