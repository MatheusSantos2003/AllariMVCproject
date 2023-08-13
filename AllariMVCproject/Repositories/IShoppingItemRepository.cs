using AllariMVCproject.Models;

namespace AllariMVCproject.Repositories
{
    public interface IShoppingItemRepository
    {
        List<ShoppingItem> GetAll();
        ShoppingItem? Get(int id);
        void Add(ShoppingItem item);
        bool Update(ShoppingItem item);
        bool Delete(int id);
    }
}
