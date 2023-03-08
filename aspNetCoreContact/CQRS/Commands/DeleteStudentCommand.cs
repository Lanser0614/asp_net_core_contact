using MediatR;

namespace aspNetCoreContact.CQRS.Commands;

public class DeleteStudentCommand : IRequest<int>
{
    public int Id { get; set; }
}