namespace CrossAgerTest.Domain.Repositories.Abstractions;

public interface IUnitOfWork
{
    public Task Commit();
}