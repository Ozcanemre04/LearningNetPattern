using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Requests
{
    public class UpdateAchievementRequest
    {
        public int Wins { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionship { get; set; }
        

        
    }
}