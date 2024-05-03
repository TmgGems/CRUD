using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class UserModel
    {
        [Key]
        [Required]

        [EmailAddress]
        public string UserName { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
