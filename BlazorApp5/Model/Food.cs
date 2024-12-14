using System.ComponentModel.DataAnnotations;

namespace BlazorApp5.Model
{
    public class Food
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="กรุณากรอกข้อมูล")]
        public string Name { get; set; }

        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Range(30.00,500.99)]
        public double Cost { get; set; }

        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Range(1, 5)]
        public int Type { get; set; }

        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Range(30.00, 200.99)]
        public double Cal {  get; set; }

        public List<SD.Topping> Topping { get; set; } = new List<SD.Topping>();

        public string CostRate()
        {
            var star = Cost switch
            {
                >=400 => "*****",
                >=300 => "****",
                >=200 => "***",
                >= 100 => "**",
                _ => "*"
            };
            return star;
        }
    }
}
