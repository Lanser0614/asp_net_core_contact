using aspNetCoreContact.CQRS.Queries;
using aspNetCoreContact.CQRS.ViewModel;
using aspNetCoreContact.Models;
using aspNetCoreContact.Repositories;
using MediatR;

namespace aspNetCoreContact.CQRS.Handlers.Read;

public class GetStudentListHandler :  IRequestHandler<GetStudentListQuery, List<StudentDetails>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<List<StudentDetails>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetStudentListAsync();
    }
}