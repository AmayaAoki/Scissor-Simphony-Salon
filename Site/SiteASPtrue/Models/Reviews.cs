using System.ComponentModel.DataAnnotations;
namespace SiteASP.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserPhoto { get; set; }
        public string? Header { get; set; }
        public string? Text { get; set; }
        public bool Checked { get; set; }
    }
}
