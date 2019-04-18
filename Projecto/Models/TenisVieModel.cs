using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecto.Models
{
    public class TenisVieModel
    {
        public int player1Id {get; set;}
        public string player1Name { get; set; }
        public int player1Point { get; set; }
        public int player2Id { get; set; }
        public string player2Name { get; set; }
        public int player2Point { get; set; }
        public int winner { get; set; }

        [Display(Name = "resultPoint")]
        public string resultPoint { get; set; }

        [Display(Name = "consecutivePointPlayer1")]
        public int consecutivePointPlayer1 { get; set; }

        [Display(Name = "consecutivePointPlayer2")]
        public int consecutivePointPlayer2 { get; set; }

    }
}