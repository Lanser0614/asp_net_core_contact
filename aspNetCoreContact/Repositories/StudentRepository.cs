using aspNetCoreContact.Configs.DataBase.ApplicationDbContext;
using aspNetCoreContact.CQRS.ViewModel;
using aspNetCoreContact.Errors;
using aspNetCoreContact.Exception;
using aspNetCoreContact.Models;
using Microsoft.EntityFrameworkCore;

namespace aspNetCoreContact.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StudentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public async Task<List<StudentDetails>> GetStudentListAsync()
    {
        
        return await _dbContext.students.ToListAsync();
    }

    public async Task<StudentDetails> GetStudentByIdAsync(int id)
    {
        var student = await _dbContext.students
            .Where(x => x.Id == id)
            .Include(x => x.Contacts)
            .FirstOrDefaultAsync();
        if (student == null)
        {
            throw new StudentNotFoundException($"Student not found by id {id}");
        }
        return student;
    }

    public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
    {
        var result = _dbContext.students.Add(studentDetails);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
    {
        _dbContext.students.Update(studentDetails);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteStudentAsync(int id)
    {
        var student = _dbContext.students.FirstOrDefault(x => x.Id == id);
        if (student == null)
        {
            throw new StudentNotFoundException($"Student not found by id {id}");
        }
        _dbContext.students.Remove(student);
        return await _dbContext.SaveChangesAsync();
    }
}