using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using WebAccountant.Application.Dtos.LeaveAllocation;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Features.LeaveAllocation.Request.Queries;
using WebAccountant.Application.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAccountant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var res = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(res);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var res = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(res);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
        {
            var res = await _mediator.Send(new AddLeaveAllocationRequest {CreateLeaveAllocationDto=createLeaveAllocationDto });
            return Ok(res);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(UpdateLeaveAllocationDto updateLeaveAllocationDto)
        {
            var res =await _mediator.Send(new UpdateLeaveAllocationRequest {UpdateLeaveAllocationDto=updateLeaveAllocationDto });
            return Ok(res);
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res=await _mediator.Send(new DeleteLeaveAllocationRequest { Id = id});
            return NoContent();
        }
    }
}
