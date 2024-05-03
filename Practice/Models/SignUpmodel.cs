using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class SignUpmodel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
