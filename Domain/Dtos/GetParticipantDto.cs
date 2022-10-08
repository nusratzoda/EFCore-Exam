namespace Domain.Dtos;

public class GetParticipantDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string LocationName { get; set; }
    public int LocationId { get; set; }
    public string GroupName { get; set; }
    public int GroupId { get; set; }
    public GetParticipantDto()
    {
        CreatedAt = DateTimeOffset.Now;
    }
}