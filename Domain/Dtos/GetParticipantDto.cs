namespace Domain.Dtos;

public class GetParticipantDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string Location { get; set; }
    public string Group { get; set; }
}