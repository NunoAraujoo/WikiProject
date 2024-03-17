namespace WikiProject.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IItemRepository Item { get; }
        void Save();
    }
}