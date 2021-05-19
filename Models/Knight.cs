using System.ComponentModel.DataAnnotations;

namespace week10day3afternoon.Models
{
    public class Knight
    {
        // public Knight(string name)
        public Knight()
        {
            // Name = name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}