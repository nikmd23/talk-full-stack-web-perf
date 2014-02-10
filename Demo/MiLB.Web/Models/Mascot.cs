using System.ComponentModel.DataAnnotations;

namespace MiLB.Web.Models
{
    public class Mascot
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string Slug { get; set; }

        public bool IsChampion { get; set; }

        [Required, MaxLength(15)]
        public string TwitterHandle { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}