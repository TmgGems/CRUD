using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class LogInModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("User Name")]
        public String UserName { get; set; }

        [Required]
        [DisplayName ("Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
