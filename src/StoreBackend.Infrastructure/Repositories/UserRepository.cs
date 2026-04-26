using Microsoft.EntityFrameworkCore;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext context;

    public UserRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetByExternalIdAsync(Guid externalId)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.ExternalId == externalId);
    }
}