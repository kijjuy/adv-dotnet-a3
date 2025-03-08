using System.ComponentModel.DataAnnotations;

namespace web_api;

public class Patient
{

    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTimeOffset CreationTime { get; set; }

    [Required]
    [StringLength(128)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(128)]
    public String LastName { get; set; }

    [Required]
    public DateTimeOffset DateOfBirth { get; set; }
}
