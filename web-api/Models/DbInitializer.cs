namespace web_api.Models;

public class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var immunizations = new Immunization[] {
        new Immunization {
            Id = Guid.Parse("6b91e976-c790-490f-bac3-6881de3502bc"),
        CreationTime = DateTimeOffset.Now,
        OfficialName = "OfficialNameOne",
        TradeName = "TradeNameOne",
        LotNumber = "1",
        ExpirationDate = DateTimeOffset.Now,
        UpdatedTime = DateTimeOffset.Now,
        },
        new Immunization {
            Id = Guid.Parse("80cad95f-cebf-4104-8d44-211e127b836a"),
        CreationTime = DateTimeOffset.Now,
        OfficialName = "OfficialNameTwo",
        TradeName = "TradeNameTwo",
        LotNumber = "2",
        ExpirationDate = DateTimeOffset.Now,
        },
        new Immunization {
            Id = Guid.Parse("6d8578a6-1095-4905-bb49-ba7f52b16bb9"),
        CreationTime = DateTimeOffset.Now,
        OfficialName = "OfficialNameThree",
        TradeName = "TradeNameThree",
        LotNumber = "3",
        ExpirationDate = DateTimeOffset.Now,
        UpdatedTime = DateTimeOffset.Now,
        },
        };

            var organizations = new Organization[] {
        new Organization {
            Id = Guid.Parse("6b91e976-c790-490f-bac3-6881de3502bc"),
        CreationTime = DateTimeOffset.Now,
    Name = "Name One",
    Type = "Type One",
    Address = "123 Main Street",
            },
        new Organization {
            Id = Guid.Parse("80cad95f-cebf-4104-8d44-211e127b836a"),
        CreationTime = DateTimeOffset.Now,
    Name = "Name Two",
    Type = "Type One",
    Address = "123 Second Street",
            },
        new Organization {
            Id = Guid.Parse("6d8578a6-1095-4905-bb49-ba7f52b16bb9"),
        CreationTime = DateTimeOffset.Now,
    Name = "Name One",
    Type = "Type Two",
    Address = "456 Third Street",
            },
        };

            var patients = new Patient[] {
        new Patient {
            Id = Guid.Parse("6b91e976-c790-490f-bac3-6881de3502bc"),
        CreationTime = DateTimeOffset.Now,
    FirstName = "Brandon",
    LastName = "Zomer",
    DateOfBirth = DateTimeOffset.Now,
        },
        new Patient {
            Id = Guid.Parse("80cad95f-cebf-4104-8d44-211e127b836a"),
        CreationTime = DateTimeOffset.Now,
    FirstName = "Huy",
    LastName = "Pham",
    DateOfBirth = DateTimeOffset.Now,
        },
        new Patient {
            Id = Guid.Parse("6d8578a6-1095-4905-bb49-ba7f52b16bb9"),
        CreationTime = DateTimeOffset.Now,
    FirstName = "Someone",
    LastName = "Else",
    DateOfBirth = DateTimeOffset.Now,
        },
        };
            var providers = new Provider[] {
        new Provider {
            Id = Guid.Parse("6b91e976-c790-490f-bac3-6881de3502bc"),
        CreationTime = DateTimeOffset.Now,
    FirstName = "Provider",
    LastName = "One",
    LicenseNumber = 1,
    Address = "123 Main Street",
        },
        new Provider {
            Id = Guid.Parse("80cad95f-cebf-4104-8d44-211e127b836a"),
        CreationTime = DateTimeOffset.Now,
    FirstName = "Provider",
    LastName = "Two",
    LicenseNumber = 1,
    Address = "123 Second Street",
        },
        new Provider {
            Id = Guid.Parse("6d8578a6-1095-4905-bb49-ba7f52b16bb9"),
        CreationTime = DateTimeOffset.Now,
    FirstName = "Provider",
    LastName = "Three",
    LicenseNumber = 1,
    Address = "456 Third Street",
        },
        };

            foreach (var immunization in immunizations)
            {
                context.ImmunizationItems.Add(immunization);
            }
            foreach (var organization in organizations)
            {
                context.Organizations.Add(organization);
            }
            foreach (var patient in patients)
            {
                context.Patients.Add(patient);
            }
            foreach (var provider in providers)
            {
                context.Providers.Add(provider);
            }
            context.SaveChanges();
        }

    }
}
