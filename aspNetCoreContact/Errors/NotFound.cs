namespace aspNetCoreContact.Errors;

public class NotFound
{
    public NotFound(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
    
}