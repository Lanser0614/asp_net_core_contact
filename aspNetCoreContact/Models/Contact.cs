namespace aspNetCoreContact.Models;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public StudentDetails StudentDetails { get; set; }
}