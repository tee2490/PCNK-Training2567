

namespace BlazorApp5.Service
{
    public class FoodService : IFoodService
    {
        Random r;
        public List<Food> Foods;

        public FoodService()
        {
            r = new Random();
            Foods = new List<Food>();
            GenData();
        }

        public void GenData(int number=5)
        {
            number = r.Next(20,31);

            for (int i = 1; i <= number; i++) {
                Foods.Add(new Food 
                {
                    Id = i,
                    Name = "Food"+i,
                    Cost = r.Next(30,501) + r.NextDouble(),
                    Type= r.Next(1,6),
                    Cal= r.Next(30, 201) + r.NextDouble(),
                });
            }


        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public List<IGrouping<int,Food>> GroupByType()
        {
          return Foods.OrderBy(px=>px.Type)
                .GroupBy(x => x.Type).ToList();
        }

        public void Add(Food food)
        {
            var id = Foods.Max(x => x.Id) + 1;
           
            food.Id = id;
            Foods.Add (food);
        }

        public void Delete(int id)
        {
            var result = Foods.Find (x => x.Id == id);
            if (result != null) Foods.Remove (result);
        }

        public void Edit(Food food)
        {

            var oldFood = Foods.FirstOrDefault(px => px.Id.Equals(food.Id));

            var index = Foods.IndexOf(oldFood);

            if (index >= 0)
            {
                Foods.RemoveAt(index);
                Foods.Insert(index, food);
            }

        }

    }
}
