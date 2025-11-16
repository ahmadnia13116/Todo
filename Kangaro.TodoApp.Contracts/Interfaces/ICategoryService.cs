using Kangaro.TodoApp.Contracts.Dtos;

namespace Kangaro.TodoApp.Contracts.Interfaces;

public interface ICategoryService
{
    Task<ListItemDto> GetAsync(
        object id,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<ListItemDto>> GetListAsync(CancellationToken cancellationToken = default);

    Task CreateAsync(
        ListItemDto item,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        object id,
        CancellationToken cancellationToken = default);
}