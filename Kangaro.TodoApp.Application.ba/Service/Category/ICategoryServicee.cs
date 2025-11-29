using System;
using System.Collections.Generic;
using System.Text;
using Kangaro.TodoApp.Contracts.Dtos;

namespace Kangaro.TodoApp.Application.ba.Service.Category
{
    public interface ICategoryServicee
    {
        Task CreateAsync(ListItemDto item, CancellationToken cancellationToken = default);
        Task DeleteAsync(object id, CancellationToken cancellationToken = default);
        Task<ListItemDto> GetAsync(object id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ListItemDto>> GetListAsync(CancellationToken cancellationToken = default);
    }

}
