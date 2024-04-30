using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models
{
    public class DistrictModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public  string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [ForeignKey("Province")]  
        public int ProvinceId {  get; set; }
        [ValidateNever]
        public virtual ProvinceModel Province { get; set; }
    }
}
