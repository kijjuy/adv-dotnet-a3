using System.ComponentModel.DataAnnotations;

namespace web_api;

public class Immunization
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTimeOffset CreationTime { get; set; }

    [Required]
    [StringLength(128)]
    public String OfficialName { get; set; }

    [StringLength(128)]
    public String? TradeName { get; set; }

    [Required]
    [StringLength(128)]
    public String LotNumber { get; set; }

    [Required]
    public DateTimeOffset ExpirationDate { get; set; }

    public DateTimeOffset UpdatedTime { get; set; }
}
