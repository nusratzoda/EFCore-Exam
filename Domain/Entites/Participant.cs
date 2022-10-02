namespace Domain.Entites;

public class Participant
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CreatedAt { get; set; }
    public int GroupId { get; set; }
    public virtual Groups? Group { get; set; }
    public int LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
