using aspNetCoreContact.CQRS.Commands;
using aspNetCoreContact.CQRS.Queries;
using aspNetCoreContact.CQRS.ViewModel;
using aspNetCoreContact.Http.Requests;
using aspNetCoreContact.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreContact.Http.Controllers.Students;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<List<StudentDetails>> GetStudentListAsync()
    {
        var studentDetails = await _mediator.Send(new GetStudentListQuery());

        return studentDetails;
    }

    [HttpGet("{id}")]
    public async Task<StudentDetails> GetStudentByIdAsync(int id)
    {
        var studentDetails = await _mediator.Send(new GetStudentByIdQuery() { Id = id });

        return studentDetails;
    }

    [HttpPost]
    public async Task<StudentDetails> AddStudentAsync(StudentDetailsRequest studentDetails)
    {
        var studentDetail = await _mediator.Send(new CreateStudentCommand(
            studentDetails.StudentName,
            studentDetails.StudentEmail,
            studentDetails.StudentAddress,
            studentDetails.StudentAge));
        return studentDetail;
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<int> UpdateStudentAsync(StudentDetailsRequest studentDetails, int id)
    {
        var isStudentDetailUpdated = await _mediator.Send(new UpdateStudentCommand(
            id,
            studentDetails.StudentName,
            studentDetails.StudentEmail,
            studentDetails.StudentAddress,
            studentDetails.StudentAge));
        
        return isStudentDetailUpdated;
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<int> DeleteStudentAsync(int id)
    {
        return await _mediator.Send(new DeleteStudentCommand() { Id = id });
    }
}