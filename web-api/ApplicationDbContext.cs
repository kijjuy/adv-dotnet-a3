using Microsoft.EntityFrameworkCore;

namespace web_api.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Immunization> ImmunizationItems { get; set; } = null;

    public DbSet<Patient> Patients { get; set; } = null;

    public DbSet<Organization> Organizations { get; set; } = null;

    public DbSet<Provider> Providers { get; set; } = null;

}
