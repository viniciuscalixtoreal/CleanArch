using CleanArch.Application.Members.Commands;
using CleanArch.Application.Members.Queries;
using CleanArch.Domain.Abstraction;
using CleanArch.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetMembersQuery();
            var members = await _mediator.Send(query);
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetMemberByIdQuery { Id = id};
            var members = await _mediator.Send(query);
            return members != null ? Ok(members) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMemberCommand command)
        {
            var createdMember = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdMember.Id }, createdMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMemberCommand command)
        {
            command.Id = id;
            var updatedMember = await _mediator.Send(command);

            return Ok(updatedMember);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMemberCommand { Id = id };
            var deletedMember = await _mediator.Send(command);

            return Ok(deletedMember);
        }
    }
}
