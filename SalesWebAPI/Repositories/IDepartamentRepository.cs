﻿using SalesWebAPI.Models;

namespace SalesWebAPI.Repositories
{
    public interface IDepartamentRepository
    {
        Task<IEnumerable<Departament>> GetAllAsync();
        Task<Departament> GetByIdAsync(int id);
        Task AddAsync(Departament departament);
        Task UpdateAsync(Departament departament);
        Task DeleteAsync(int id);
        bool DepartamentExists(int id);
    }
}
