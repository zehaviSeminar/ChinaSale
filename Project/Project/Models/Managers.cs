using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Managers
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
    }
}
