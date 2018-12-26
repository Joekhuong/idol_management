using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lodi.Models
{
    public class Idol
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public virtual ICollection<ApplicationUser> Followers { get; set; }

        //[Required]
        public virtual Forum Forum { get; set; }

        public Idol()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}