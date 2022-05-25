namespace DataBaseService.Logger
{
    public interface ILoggerManager
    {
        void Write(NLog.LogLevel level, string message);
    }
}
