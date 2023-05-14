namespace MyShopCore.Web.API.Brokers.Loggings
{
    public interface ILogginBrocker
    {
        void LogInformation(string message);
        void LogTrace(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}
