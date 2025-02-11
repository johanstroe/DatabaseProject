﻿using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class 
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var result = await _dbSet.AnyAsync(expression);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


    // CREATE

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            Debug.WriteLine($"📌 Försöker lägga till entitet i databasen: {entity}");
            await _dbSet.AddAsync(entity);
            int rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected > 0)
            {
                Debug.WriteLine($"✅ {rowsAffected} rad(er) sparades i databasen!");
                return entity;
            }
            else
            {
                Debug.WriteLine($"❌ Inga rader sparades i databasen.");
                return null!;
            }
           
        }
        catch (DbUpdateException dbEx)
        {
            Debug.WriteLine($"❌ DbUpdateException: {dbEx.Message}");
            if (dbEx.InnerException != null)
                Debug.WriteLine($"🔍 Inner Exception: {dbEx.InnerException.Message}");
            
            return null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"❌ Exception vid CreateAsync: {ex.Message}");
            return null!;
        }
    }

    // READ

    public virtual async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public virtual async Task<IEnumerable<TEntity>?> GetAllAsync()
    {
        try
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }
        catch (Exception)
        {
            return [];
        }
    }

    // UPDATE

    public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        try
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(expression);
            if (existingEntity != null && updatedEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return existingEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    // DELETE

    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _dbSet.FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }


}