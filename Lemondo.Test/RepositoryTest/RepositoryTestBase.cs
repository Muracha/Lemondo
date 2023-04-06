namespace Lemondo.Test.RepositoryTest;

public abstract class RepositoryTestBase<TEntity, TRepository> : IClassFixture<DbFixture>
    where TEntity : class, IModel, new()
    where TRepository : IRepositoryBase<TEntity>
{
    protected TEntity Model { get; set; }
    protected TRepository Repository { get; set; }


    [Fact]
    public async Task GetAsync()
    {
        await Repository.InsertAsync(Model);
        await Repository.SaveChangesAsync();

        Assert.True(Repository.Get(Model.Id) != null);
    }

    [Fact]
    public async Task SetPredicateAsync()
    {
        await Repository.InsertAsync(Model);
        await Repository.SaveChangesAsync();

        Assert.True(Repository.Set(x => x.Id == Model.Id) != null);
    }

    [Fact]
    public async Task SetAsync()
    {
        await Repository.InsertAsync(Model);
        await Repository.SaveChangesAsync();

        Assert.True(Repository.Set() != null);
    }

    [Fact]
    public async Task InsertAsync()
    {
        await Repository.InsertAsync(Model);
        await Repository.SaveChangesAsync();

        Assert.True(Model.Id != 0);
    }

    [Fact]
    public abstract Task UpdateAsync();

    [Fact]
    public async Task DeleteByEntityAsync()
    {
        await Repository.InsertAsync(Model);
        await Repository.SaveChangesAsync();

        if (Model.Id == 0)
        {
            throw new Exception("Entity Model was not found");
        }

        Repository.Delete(Model);
        await Repository.SaveChangesAsync();

        Assert.Throws<KeyNotFoundException>(() => Repository.Get(Model.Id));
    }

    [Fact]
    public async Task DeleteByIdAsync()
    {
        Repository.Insert(Model);
        await Repository.SaveChangesAsync();

        if (Model.Id == 0)
        {
            throw new Exception("Entity Model was not found");
        }

        Repository.Delete(Model.Id);
        await Repository.SaveChangesAsync();

        Assert.Throws<KeyNotFoundException>(() => Repository.Get(Model.Id));
    }
}