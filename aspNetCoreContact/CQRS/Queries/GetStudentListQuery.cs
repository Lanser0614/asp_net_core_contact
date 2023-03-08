using aspNetCoreContact.CQRS.ViewModel;
using aspNetCoreContact.Models;
using MediatR;

namespace aspNetCoreContact.CQRS.Queries;

public class GetStudentListQuery :  IRequest<List<StudentDetails>>
{
    
}