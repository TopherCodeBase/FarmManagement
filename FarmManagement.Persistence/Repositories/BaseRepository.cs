﻿using FarmManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);
            return t;
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);
            return t;
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
