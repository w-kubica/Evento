namespace Evento.Infrastructure.DTO;
public class EventDetailsDto : EventDto
{
    public IEnumerable<TicketDto>Tickets { get; set; }
}
