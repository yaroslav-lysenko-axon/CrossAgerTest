using CrossAgerTest.Application.Models.Responses.Table;
using MediatR;

namespace CrossAgerTest.Application.Models.Commands.Table;

public class GetTablesCommand : IRequest<IReadOnlyCollection<TableResponseModel>>;