namespace Kangaro.TodoApp.Contracts.Interfaces;

public interface IHealthCheckService
{
    Task HealthAsync(CancellationToken cancellationToken = default);
}