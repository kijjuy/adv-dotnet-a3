using Microsoft.EntityFrameworkCore;

namespace web_api.Models;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
	    :base(options)
	{
	}

	public DbSet<Immunization> ImmunizationItems { get; set; } = null;

	public DbSet<Organization> OrganizationItems { get; set; } = null;

	public DbSet<Patient> PatientItems { get; set; } = null;

	public DbSet<Provider> ProviderItems { get; set; } = null;
}
