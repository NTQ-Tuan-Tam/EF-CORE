using System.ComponentModel.DataAnnotations;

namespace Curd.Models
{
    public class Contact
    {
        [Range(1, 10)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

       
        public int Phone { get; set; }


        [Required]
        [StringLength(500)]
        public string Note { get; set; }
    }
}
