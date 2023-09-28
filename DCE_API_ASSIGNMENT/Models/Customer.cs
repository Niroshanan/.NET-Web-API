﻿using System.ComponentModel.DataAnnotations;

namespace DCE_API_ASSIGNMENT.Models
{
    public class Customer
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}