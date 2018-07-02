using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Value { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        public int GameId { get; set; }

        [ForeignKey("AspNetUserId")]
        public virtual User User { get; set; }
        public string AspNetUserId { get; set; }
    }
}
