using System.ComponentModel.DataAnnotations;

namespace web_api

{
    public class Provider
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTimeOffset CreationTime { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public uint LicenseNumber { get; set; }

        [Required]
        public String Address { get; set; }

    }
}


