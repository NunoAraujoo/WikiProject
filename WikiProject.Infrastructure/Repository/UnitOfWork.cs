using WikiProject.Infrastructure.Data;
using WikiProject.Application.Common.Interfaces;
using WikiProject.Infrastructure.Repository;

namespace WikiProject.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IItemRepository Item { get; private set; } = null!;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Item = new ItemRepository(_db);
        }

        public void Save() {
            _db.SaveChanges();
        }
    }
}