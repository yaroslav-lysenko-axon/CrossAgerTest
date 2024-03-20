using CrossAgerTest.Domain.Models.Enums;

namespace CrossAgerTest.Domain.Models.DbEntities;

public class ClientsGroup
{
    public int Id { get; set; }
    public int? TableId { get; set; }
    public int Size { get; set; }
    public ClientsGroupState State { get; set; }
    public DateTime ArrivedAt { get; set; }
    public Table Table { get; set; }
}