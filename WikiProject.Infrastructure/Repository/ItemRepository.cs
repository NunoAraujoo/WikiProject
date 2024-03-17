using WikiProject.Domain.Entities;
using WikiProject.Infrastructure.Data;
using WikiProject.Application.Common.Interfaces;

namespace WikiProject.Infrastructure.Repository
{
    public class ItemRepository(ApplicationDbContext db) : Repository<Item>(db), IItemRepository
    {
        private readonly ApplicationDbContext _db = db;



        public void Update(Item entity)
        {
            _db.Items.Update(entity);
        }
    }
}