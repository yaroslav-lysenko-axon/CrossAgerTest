namespace CrossAgerTest.Domain.Models.DbEntities;

public class Table
{
    public int Id { get; set; }
    public int Size { get; set; }
    public int EmptyChairs { get; set; }
    public ICollection<ClientsGroup> ClientsGroups { get; set; }
}