using AllariMVCproject.Models;

namespace AllariMVCproject.Repositories
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private List<ShoppingItem> items = new List<ShoppingItem>();
        private int Id = 1;

        public ShoppingItemRepository() 
        {
            Add(new ShoppingItem { Id = 1, Description = "Soda" } );
            Add(new ShoppingItem { Id = 2, Description = "Pasta" } );
            Add(new ShoppingItem { Id = 3, Description = "Olive Oil" });
        }


        public void Add(ShoppingItem item)
        {
            items.Add(item);  
        }

        public bool Delete(int id)
        {
            items.RemoveAll(p => p.Id == id);
            return true;
        }

        public ShoppingItem? Get(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public List<ShoppingItem> GetAll()
        {
            return items;
        }

        public bool Update(ShoppingItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = items.FindIndex(p => p.Id == item.Id);
            if (index == -1) {
                return false;
            }

            items.RemoveAt(index);
            items.Add(item);
            return true;
        }

   
    }
}
