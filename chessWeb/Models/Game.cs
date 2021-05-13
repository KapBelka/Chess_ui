using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace chessWeb.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public User Player { get; set; }
        public int OpponentPlayerId { get; set; }
        public chess.Colors color { get; set; }
        public DateTime Date { get; set; }
        public bool Win { get; set; }
    }
}
