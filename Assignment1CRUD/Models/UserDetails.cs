using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1CRUD.Models
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, 9999999)]
        [Column(Order = 0, TypeName = "int")]
        public int userId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 1)]
        public string name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 2)]
        public string email { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 3)]
        public string password { get; set; }

    }
}
