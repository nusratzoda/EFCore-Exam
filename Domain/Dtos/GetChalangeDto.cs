using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class GetChalangeDto
{

    public int Id { get; set; }
    public int ChallangeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}