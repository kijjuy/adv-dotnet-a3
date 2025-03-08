using System.ComponentModel.DataAnnotations;

namespace web_api

{
    public class Organization
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTimeOffset CreationTime { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        public String Name { get; set; }

        [Required]
        public String Type { get; set; }

        [Required]
        public String Address { get; set; }

    }
}


