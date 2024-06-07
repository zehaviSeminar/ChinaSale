
using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class Donors
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Presents> Donations { get; set; }
    }
}
