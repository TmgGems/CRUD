using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class CountryModel
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Code { get; set; }

        [StringLength(30)]
        public string Name { get; set; }


    }
}
