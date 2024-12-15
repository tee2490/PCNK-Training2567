

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

        public void GenData(int number = 5)
        {
            number = r.Next(20, 31);

            for (int i = 1; i <= number; i++)
            {
                //random Topping แถมเฉยๆ
                var tempTopping = new List<SD.Topping>();
                var element = Enum.GetValues<SD.Topping>().Count();
                var n  = r.Next(1,element+1); //สุ่มจำนวนกี่ตัว

                for (int j = 1; j <= n; j++) 
                {
                    var t = (SD.Topping)r.Next(0, element); //สุ่มค่า
                    tempTopping.Add(t);
                }


                Foods.Add(new Food
                {
                    Id = i,
                    Name = "Food" + i,
                    Cost = r.Next(30, 501) + r.NextDouble(),
                    Type = (SD.Types)r.Next(1, 6),
                    Cal = r.Next(30, 201) + r.NextDouble(),
                    Topping = tempTopping.Distinct().Order().ToList()
                });
            }


        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public List<IGrouping<SD.Types, Food>> GroupByType()
        {
            return Foods.OrderBy(px => px.Type)
                  .GroupBy(x => x.Type).ToList();
        }

        public void Add(Food food)
        {
            var id = Foods.Max(x => x.Id) + 1;

            food.Id = id;
            Foods.Add(food);
        }

        public void Delete(int id)
        {
            var result = Foods.Find(x => x.Id == id);
            if (result != null) Foods.Remove(result);
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

        public Food FindbyId(int id)
        {
            var food = Foods.FirstOrDefault(px => px.Id.Equals(id));
            return food;
        }

    }
}
