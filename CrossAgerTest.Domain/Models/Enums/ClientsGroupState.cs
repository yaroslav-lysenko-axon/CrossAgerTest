using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CrossAgerTest.Domain.Models.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ClientsGroupState
{
    Waiting,
    Seated,
    Completed
}