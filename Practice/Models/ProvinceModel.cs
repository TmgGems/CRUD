using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class ProvinceModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(5)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        [ValidateNever]
        public virtual CountryModel Country { get; set; }
    }
}
