namespace SiteASP.Models
{
    public class Services
    {
        //public Services() { }
        public int Id { get; set; }
        public string? ProcedureName { get; set; }
        public string? Description { get; set; }
        public ushort Cost { get; set; }
        public string? Photo { get; set; }
        public int CategoryID {set; get;}
        public virtual Category? Category { get; set; }

    }
}
