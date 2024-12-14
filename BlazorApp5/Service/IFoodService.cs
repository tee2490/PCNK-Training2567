namespace BlazorApp5.Service
{
    public interface IFoodService
    {
        void GenData(int number);
        void GetAll();
        List<IGrouping<int,Food>> GroupByType();
        void Delete(int id);
        void Add(Food food);
        void Edit(Food product);
    
    }
}
