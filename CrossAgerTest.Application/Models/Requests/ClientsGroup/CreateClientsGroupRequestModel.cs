using System.ComponentModel.DataAnnotations;

namespace CrossAgerTest.Application.Models.Requests.ClientsGroup;

public class CreateClientsGroupRequestModel
{
    [Required, Range(1, 6)]
    public int Size { get; set; }
}