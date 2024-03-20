using CrossAgerTest.Domain.Contexts;
using CrossAgerTest.Domain.Models.DbEntities;
using CrossAgerTest.Domain.Repositories.Abstractions;

namespace CrossAgerTest.Domain.Repositories;

public class TableRepository(CrossAgerDbContext context)
    : GenericRepository<Table>(context.Tables), ITableRepository;