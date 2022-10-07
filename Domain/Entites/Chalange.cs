namespace Domain.Entites;

public class Chalange
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int LocationId { get; set; }
    public string Location { get; set; }
    public virtual List<Group> Groups { get; set; }

}
