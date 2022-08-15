using Evento.Infrastructure.Commands.Events;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Evento.API.Controllers;

[Route("[controller]")]

public class EventsController : Controller
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }
    [HttpGet]
    public async Task<IActionResult> Get (string name)
    {
        var events = await _eventService.BrowseAsync(name);
        return Ok(events);
    }

    [HttpGet("{eventId}")]
    public async Task<IActionResult> Get(Guid eventId)
    {
        var @event = await _eventService.GetAsync(eventId);
        if (@event == null)
        {
            return NotFound();
        }
        return Ok(@event);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]CreateEvent command)
    {
        command.EventId = Guid.NewGuid();
        await _eventService.CreateAsync(command.EventId, command.Name, command.Description,command.StartDate, command.EndDate);
        await _eventService.AddTicketAsync(command.EventId, command.Tickets, command.Price);

        //201 z url do nowo utworzonego zasobu
        return Created($"events/{command.EventId}", null);
    }

    [HttpPut("{eventId}")]
    public async Task<IActionResult> Put(Guid eventId, [FromBody] UpdateEvent command)
    {
        await _eventService.UpdateAsync(eventId, command.Name, command.Description);

        //204
        return NoContent();
    }

    [HttpDelete("{eventId}")]
    public async Task<IActionResult> Delete(Guid eventId)
    {
        await _eventService.DeleteAsync(eventId);

        //204
        return NoContent();
    }

}
