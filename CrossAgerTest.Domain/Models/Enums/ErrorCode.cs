using System.ComponentModel.DataAnnotations;

namespace CrossAgerTest.Domain.Models.Enums;

public enum ErrorCode
{
    [Display(Name = "entityNotFoundException")]
    EntityNotFoundException,
    [Display(Name = "validationFailed")]
    ValidationFailed,
}