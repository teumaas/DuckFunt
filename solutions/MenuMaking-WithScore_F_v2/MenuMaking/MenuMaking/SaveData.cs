using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuMaking
{
    class SaveData
    {
        [Serializable]
        public struct HighScoreData
        { 
            public string[] playerName;
            public decimal[] kills;
            public decimal[] shotsFired;
            public int count;
            public HighScoreData(int countConstruct)
            {
                count = countConstruct;
                playerName = new string[count];
                kills = new decimal[count];
                shotsFired = new decimal[count];
                
            }
        }

    }
}
