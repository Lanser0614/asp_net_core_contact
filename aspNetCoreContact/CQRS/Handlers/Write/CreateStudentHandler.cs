using aspNetCoreContact.CQRS.Commands;
using aspNetCoreContact.Models;
using aspNetCoreContact.Repositories;
using MediatR;

namespace aspNetCoreContact.CQRS.Handlers.Write;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
{
    private readonly IStudentRepository _studentRepository;

    public CreateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<StudentDetails> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = new StudentDetails()
        {
            StudentName = command.StudentName,
            StudentEmail = command.StudentEmail,
            StudentAddress = command.StudentAddress,
            StudentAge = command.StudentAge
        };

        return await _studentRepository.AddStudentAsync(studentDetails);
    }
}