using aspNetCoreContact.Models;
using MediatR;

namespace aspNetCoreContact.CQRS.Queries;

public class GetStudentByIdQuery : IRequest<StudentDetails>
{
    public int Id { get; set; }
}