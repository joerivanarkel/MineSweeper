namespace MineSweeperLogic;

public interface ILogger
{
    List<Log> Logs { get; set; }

    void Log(string message);
}
