using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecto.Models
{
    public class PointViewModel
    {
        public PointViewModel(){}

        public PointViewModel(int poinWin, int poinPlay)
        {
            this.poinPlay = poinPlay;
            this.poinWin = poinWin;
        }

        public int poinWin { get; set; }
        public int poinPlay { get; set; }
    }
}