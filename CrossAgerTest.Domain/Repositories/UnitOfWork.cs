using CrossAgerTest.Domain.Contexts;
using CrossAgerTest.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CrossAgerTest.Domain.Repositories;

public class UnitOfWork(CrossAgerDbContext databaseContext) : IUnitOfWork
{
    public async Task Commit()
    {
        try
        {
            await databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.InnerException?.Message);
            throw;
        }
    }
}