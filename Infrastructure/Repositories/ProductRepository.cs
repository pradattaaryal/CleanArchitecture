using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using practices.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace;

namespace practices.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            await ExecuteInTransactionAsync(async () =>
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            });
        }

        public async Task UpdateProductAsync(Product product)
        {
            await ExecuteInTransactionAsync(async () =>
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            });
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                await ExecuteInTransactionAsync(async () =>
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                });
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        private async Task ExecuteInTransactionAsync(Func<Task> action)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
