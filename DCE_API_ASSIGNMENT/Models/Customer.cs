using System.ComponentModel.DataAnnotations;

namespace DCE_API_ASSIGNMENT.Models
{
    public class Customer
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(20)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; }
    }
}
