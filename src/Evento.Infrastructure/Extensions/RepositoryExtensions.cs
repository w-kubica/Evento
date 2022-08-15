using Evento.Core.Domain;
using Evento.Core.Repositories;

namespace Evento.Infrastructure.Extensions;
public static class RepositoryExtensions
{
    public static async Task<Event> GetOrFailAsync(this IEventRepository repository, Guid id)
    {
        var @event = await repository.GetAsync(id);
        if (@event == null)
        {
            throw new Exception($"Event with id: {id} does not exist.");
        }

        return @event;
    }
}
