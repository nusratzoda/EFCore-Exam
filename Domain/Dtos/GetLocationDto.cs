namespace Domain.Dtos;
using System.ComponentModel.DataAnnotations;

public class GetLocationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int ChallangeId { get; set; }
    public List<GetChalangeDto> Chalanges { get; set; }

}