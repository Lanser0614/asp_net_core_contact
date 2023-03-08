using System.ComponentModel.DataAnnotations;

namespace aspNetCoreContact.Http.Requests;

public class StudentDetailsRequest
{
    [Required, MaxLength(30), MinLength(3)]
    public string StudentName { get; set; }
    
    [Required, EmailAddress]
    public string StudentEmail { get; set; }
    
    public string StudentAddress { get; set; }
    
    [Required]
    public int StudentAge { get; set; }
}