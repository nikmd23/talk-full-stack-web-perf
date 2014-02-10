using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiLB.Web.Models
{
    public class League
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Name { get; set; }

        [Required, MaxLength(15)]
        public string Slug { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}