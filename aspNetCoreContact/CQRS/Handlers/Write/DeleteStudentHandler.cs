using aspNetCoreContact.CQRS.Commands;
using aspNetCoreContact.Repositories;
using MediatR;

namespace aspNetCoreContact.CQRS.Handlers.Write;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);

        return await _studentRepository.DeleteStudentAsync(studentDetails.Id);
    }
}