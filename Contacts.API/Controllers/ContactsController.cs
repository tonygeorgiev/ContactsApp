using Contacts.Application.Contacts;
using Contacts.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST: api/Contacts
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody]ContactRequest contact)
    {
        await _mediator.Send(new AddContactCommand(contact));

        return NoContent();
    }

    // GET: api/Contacts
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAll()
    {
        var query = new GetAllContactsQuery();
        var contact = await _mediator.Send(query);

        return Ok(contact);
    }
}
