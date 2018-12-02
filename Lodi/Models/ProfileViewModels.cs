using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lodi.Models
{
    public class ProfileViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Region")]
        public Region Region { get; set; }

        [Required]
        [Display(Name = "Idols")]        
        public System.Web.Mvc.SelectList Idol_List { get; set; }
    }
}