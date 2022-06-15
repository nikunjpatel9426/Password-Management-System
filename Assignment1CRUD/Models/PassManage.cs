using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1CRUD.Models
{
    public class PassManage
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, 9999999)]
        [Column(Order = 0, TypeName = "int")]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 1)]
        public string name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 2)]
        public string userName { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 3)]
        public string password { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 4)]
        public string link { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 5)]
        public string description { get; set; }
    }
}
