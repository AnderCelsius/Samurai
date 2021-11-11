using System;

namespace Upskillz.Models
{
    public class BattleSamurai
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;
    }
}
