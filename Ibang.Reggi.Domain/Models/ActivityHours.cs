using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ibang.Reggi.Domain.Models
{
    public class ActivityHours
    {
        [Key]
        public Guid IdActivityHour { get; set; }

        public DateTime DateHour { get; set; }

        public int Hour { get; set; }

        public Guid IdActivity { get; set; }

        [ForeignKey("IdActivity")]
        public Activity Activity { get; set; }
    }
}
