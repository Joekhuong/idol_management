using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lodi.Models
{
    public class Region
    {
        [Key]
        [Required]        
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public Region()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}