using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Practice.Models.CountryModel> CountryModel { get; set; } = default!;
        public DbSet<Practice.Models.ProvinceModel> ProvinceModel { get; set; } = default!;

        public DbSet<DistrictModel> DistrictModel { get; set; } 

        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<Practice.Models.LogInModel> LogInModel { get; set; } = default!;
        public DbSet<Practice.Models.SignUpmodel> SignUpmodel { get; set; } = default!;
    }
}
