﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGUI
{
    public class GameStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
    }

}
