using Microsoft.EntityFrameworkCore;
using Api.Domain.Interfaces;
using Api.Domain.Entities;
using Api.Data.Context;

namespace Api.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dataSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var response = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

                return response ?? null!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty) item.Id = Guid.NewGuid();
                item.CreateAt = DateTime.UtcNow;
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var response = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (response == null) return null!;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = response.CreateAt;
                _context.Entry(response).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var response = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (response == null) return false;

                _dataSet.Remove(response);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }
    }
}
