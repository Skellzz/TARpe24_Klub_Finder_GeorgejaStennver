namespace Klub_Finder.Models
{
    public class Toit
    {
        public int Id { get; set; }
        public string FoodName { get; set;}
        public DateTime RegisteerimisKuupäev { get; set; } = DateTime.Now;
    }
}
