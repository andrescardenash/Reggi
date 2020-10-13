using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ibang.Reggi.Domain.Models
{
    public class Activity
    {
        [Key]
        public Guid IdActivity { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public ICollection<ActivityHours> ActivityHours { get; set; }
    }
}
