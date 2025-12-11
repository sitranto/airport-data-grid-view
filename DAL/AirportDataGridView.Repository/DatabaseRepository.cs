using AirportDataGridView.Context;
using AirportDataGridView.Entities.Models;
using AirportDataGridView.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirportDataGridView.Repository
{
    public class DatabaseRepository : IStorage
    {
        public async Task Add(Plane item, CancellationToken cancellationToken = default)
        {
            using var context = new DatabaseContext();
            context.Add(item);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Plane item, CancellationToken cancellationToken = default)
        {
            using var context = new DatabaseContext();
            context.Remove(item);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Plane>> GetAll(CancellationToken cancellationToken = default)
        {
            using var context = new DatabaseContext();
            return await context.Planes.ToListAsync(cancellationToken);
        }

        public async Task Update(Plane item, CancellationToken cancellationToken = default)
        {
            using var context = new DatabaseContext();
            context.Update(item);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
