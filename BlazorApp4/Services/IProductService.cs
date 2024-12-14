using BlazorApp4.Models;

namespace BlazorApp4.Services
{
    public interface IProductService
    {
        void GenData(int number);
        void Add(Product product);
        void Delete(int id);
        void Edit(Product product);
        Product FindbyId(int id);
    }
}
