using MyWebApp.Services; // Include the Models namespace to access Product

public interface IAppLogger
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message, Exception ex);
}
