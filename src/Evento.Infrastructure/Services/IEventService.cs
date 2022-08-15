using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Services;
public interface IEventService
{
    Task<EventDetailsDto> GetAsync(Guid id);

    Task<EventDetailsDto> GetAsync(string name);

    Task<IEnumerable<EventDto>> BrowseAsync(string name = null);

    Task CreateAsync(Guid id, string name, string description, DateTime StartDate, DateTime EndDate);

    Task UpdateAsync(Guid id, string name, string description);

    Task DeleteAsync(Guid id);

    Task AddTicketAsync(Guid eventId, int amount, decimal price);
}
