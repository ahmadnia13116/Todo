using System;
using System.Collections.Generic;
using System.Text;
using Kangaro.TodoApp.Contracts.Dtos;

namespace Kangaro.TodoApp.Application.ba.Service.Category
{
    public class CategoryService : ICategoryServicee
    {
        private static readonly List<ListItemDto> _items = new();

        public Task CreateAsync(ListItemDto item, CancellationToken cancellationToken = default)
        {
            item.Id = Guid.NewGuid();
            _items.Add(item);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            var guid = Guid.Parse(id.ToString()!);

            var entity = _items.FirstOrDefault(x => x.Id == guid);
            if (entity != null)
                _items.Remove(entity);

            return Task.CompletedTask;
        }

        public Task<ListItemDto?> GetAsync(object id, CancellationToken cancellationToken = default)
        {
            var guid = Guid.Parse(id.ToString()!);

            var entity = _items.FirstOrDefault(x => x.Id == guid);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<ListItemDto>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_items.AsEnumerable());
        }
    }
}