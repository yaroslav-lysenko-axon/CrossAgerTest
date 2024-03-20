using System.Net;
using CrossAgerTest.Domain.Models.Enums;

namespace CrossAgerTest.Domain.Exceptions;

public abstract class ApplicationException(
    ErrorCode errorCode,
    HttpStatusCode statusCode,
    string? message) : Exception(message)
{
    public ErrorCode ErrorCodeValue { get; } = errorCode;
    public HttpStatusCode StatusCode { get; } = statusCode;
}