using System.ComponentModel.DataAnnotations;

namespace web_api;

public class Immunization
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTimeOffset CreationTime { get; set; }

    [Required]
    public String OfficialName { get; set; }

    public String? TradeName { get; set; }

    [Required]
    public String LotNumber { get; set; }

    public DateTimeOffset ExpirationDate { get; set; }
}
