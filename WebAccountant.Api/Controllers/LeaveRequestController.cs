using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAccountant.Application.Dtos.LeaveRequest;
using WebAccountant.Application.Features.LeaveRequest.Request.Command;
using WebAccountant.Application.Features.LeaveRequest.Request.Queries;
using WebAccountant.Application.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAccountant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<LeaveRequestSelectDto>> Get()
        {
            var res=await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(res);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<LeaveRequestDto> Get(int id)
        {
           var res=await _mediator.Send(new GetLeaveRequestDetailRequest { Id= id });
            return res;
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var res = await _mediator.Send(new AddLeaveRequestRequest { CreateLeaveRequestDto = createLeaveRequestDto });
            return Ok(res);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var res = await _mediator.Send(new UpdateLeaveRequestRequest {Id=id ,UpdateLeaveRequestDto = updateLeaveRequestDto });
            return NoContent();
        }
        // PUT api/<LeaveRequestController>/5
        [HttpPut("ChangeApproved")]
        public async Task<ActionResult> ChangeApproved(int id, ChangeApprovedLeaveRequestDto changeApprovedLeaveRequestDto)
        {
            var res = await _mediator.Send(new UpdateLeaveRequestRequest { Id = id, ChangeApprovedLeaveRequestDto = changeApprovedLeaveRequestDto });
            return NoContent();
        }
        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res=await _mediator.Send(new DeleteLeaveRequestRequest { Id = id });
            return NoContent();
        }
    }
}
