using System;
using System.Collections.Generic;
using System.Text;

namespace Targil5
{
    internal struct Player
    {
        private readonly string r_Name;
        private int m_Score;

        public Player(string i_Name, int i_Score)
        {
            r_Name = i_Name;
            m_Score = i_Score;
        }
        
        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }
    }
}
