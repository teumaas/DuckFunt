using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuMaking
{
    class SaveData
    {
        [Serializable]
        private struct HighScoreData
        {
            public string playerName;
            public decimal kills;
            public decimal shotsFired;
            public decimal rounds;
        }

    }
}
