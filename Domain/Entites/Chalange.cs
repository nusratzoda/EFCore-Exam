namespace Domain.Entites;

public class Chalange
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<Groups> Groupes { get; set; }
}
