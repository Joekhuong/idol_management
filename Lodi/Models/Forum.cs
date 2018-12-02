using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lodi.Models
{
    [Table("Forum")]
    public class Forum
    {
        [ForeignKey("Idol")]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Idol Idol { get; set; }
        
        public Forum()
        {
            //Id = Guid.NewGuid().ToString();
        }
    }
}