using System.ComponentModel.DataAnnotations;

namespace MiLB.Web.Models
{
    public class Team
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string Name { get; set; }

        [Required, MaxLength(25)]
        public string Slug { get; set; }

        public int LeagueId { get; set; }
        public virtual League League { get; set; }

        [Required]
        public virtual Mascot Mascot { get; set; }
    }
}