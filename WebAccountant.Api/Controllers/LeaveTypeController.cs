using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAccountant.Application.Dtos.LeaveType;
using WebAccountant.Application.Features.LeaveType.Request.Command;
using WebAccountant.Application.Features.LeaveType.Request.Queries;
using WebAccountant.Application.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAccountant.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var res =await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(res);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var res=await _mediator.Send(new GetLeaveTypeDetailRequest{Id=id });
            return Ok(res);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto CreateLeaveTypeDto)
        {
            var res = await _mediator.Send(new AddLeaveTypeRequest { CreateLeaveTypeDto = CreateLeaveTypeDto });
            return Ok(res);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(UpdateLeaveTypeDto updateLeaveTypeDto)
        {
            var res = await _mediator.Send(new UpdateLeaveTypeRequest {UpdateLeaveTypeDto=updateLeaveTypeDto });
            return Ok(res);
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res=_mediator.Send(new DeleteLeaveTypeRequest { Id=id});
            return NoContent();
           
        }
    }
}
