namespace aspNetCoreContact.Exception;

public class StudentNotFoundException : System.Exception
{
    public StudentNotFoundException(string message): base(message)
    {
        
    }
}