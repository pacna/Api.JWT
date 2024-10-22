using Api.JWT.Contexts;
using Api.JWT.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.JWT.Repositories;

internal class JWTRepository(JWTContext context) : IJWTRepository
{
    public async Task<JWTEntity?> GetAsync(string id)
    {
        return await context.JWT.FindAsync(id);
    }

    public async Task<JWTEntity?> GetByTokenAsync(string token)
    {
        return await context.JWT.FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task AddAsync(JWTEntity entity)
    {
        await context.AddAsync(entity);
    }

    public async Task DeleteByTokenAsync(string token)
    {
        JWTEntity? entity = await GetByTokenAsync(token);

        if (entity == null)
        {
            return;
        }
        
        context.JWT.Remove(entity);
    }
}