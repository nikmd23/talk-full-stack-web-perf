using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiLB.Web.Models
{
    public class Rum
    {
        [Required, Key]
        public int Id { get; set; }

        public virtual ICollection<ResourceTiming> Resources { get; set; }
        
        public virtual NavigationTiming Navigation { get; set; }
        
        public virtual ICollection<UserTiming> Marks { get; set; }
        
        public virtual ICollection<UserTiming> Measures { get; set; }
    }
}