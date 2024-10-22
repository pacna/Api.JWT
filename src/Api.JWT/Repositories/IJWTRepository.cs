using Api.JWT.Repositories.Entities;

namespace Api.JWT.Repositories;

public interface IJWTRepository
{
    Task<JWTEntity?> GetAsync(string id);
    Task<JWTEntity?> GetByTokenAsync(string token);
    Task AddAsync(JWTEntity entity);
    Task DeleteByTokenAsync(string token);
}