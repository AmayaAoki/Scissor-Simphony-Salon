namespace SiteASP.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public List<Services>? services {set; get;}
    }
}
