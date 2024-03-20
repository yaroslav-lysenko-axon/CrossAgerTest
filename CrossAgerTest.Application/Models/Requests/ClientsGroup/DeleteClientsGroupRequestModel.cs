using System.ComponentModel.DataAnnotations;

namespace CrossAgerTest.Application.Models.Requests.ClientsGroup;

public class DeleteClientsGroupRequestModel
{
    [Required]
    public int Id { get; set; }
}