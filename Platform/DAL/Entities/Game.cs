using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    [Table("Games")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
                 = new List<Score>();

    }
}
