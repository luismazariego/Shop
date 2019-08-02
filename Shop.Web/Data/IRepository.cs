using System.Collections.Generic;
namespace Shop.Web.Data
{
    using System.Threading.Tasks;
    using Shop.Web.Data.Entities;

    public interface IRepository
    {
        void AddProduct(Product product);

        Product GetProduct(int id);

        IEnumerable<Product> GetProducts();

        bool ProductExists(int id);

        void RemoveProduct(Product product);

        Task<bool> SaveAllAsync();

        void UpdateProduct(Product product);
    }
}