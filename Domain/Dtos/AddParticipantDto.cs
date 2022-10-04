using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddParticipantDto
{
    public int Id { get; set; }
    [Required, MaxLength(200)]

    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
}
