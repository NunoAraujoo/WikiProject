using WikiProject.Domain.Entities;

namespace WikiProject.Application.Common.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        void Update(Item entity);
    }
}