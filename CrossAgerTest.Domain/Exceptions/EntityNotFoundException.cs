using System.Net;
using CrossAgerTest.Domain.Models.Enums;

namespace CrossAgerTest.Domain.Exceptions;

public class EntityNotFoundException : ApplicationException
{
    public EntityNotFoundException(string tableName)
        : base(ErrorCode.EntityNotFoundException, HttpStatusCode.NotFound,
            $"{tableName} entity with specified identifier was not found.")
    {
    }
}