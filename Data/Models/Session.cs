using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Data.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MonsterKillCount { get; set; }

        [Required]
        [ForeignKey(nameof(GameLog))]
        public int GameLogId { get; set; }
        public GameLog GameLog { get; set; }
    }
}
