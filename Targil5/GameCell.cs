using System;
using System.Collections.Generic;
using System.Text;

namespace Targil5
{
    public struct GameCell
    {
        private int m_Value; 
        private bool m_IsVisible;

        public GameCell(int i_Value)
        {
            m_Value = i_Value;
            m_IsVisible = false;
        }

        public bool IsVisible
        {
            get
            {
                return m_IsVisible;
            }

            set
            {
                m_IsVisible = value;
            }
        }

        public int Value
        {
            get
            {
                return m_Value;
            }

            set
            {
                m_Value = value;
            }
        }
    }
}
