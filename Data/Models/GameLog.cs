using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Data.Models
{
    public class GameLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CharacterClass { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Agility { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }

        public Session Session { get; set; }
    }
}
