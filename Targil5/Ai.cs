using System;
using System.Collections.Generic;
using System.Text;

namespace Targil5
{
   internal class AI
    {
        private Board m_MemoryBoardOfPc;
        private Board m_GameBoard;
        private bool m_IsPairForNextTurn;
        private int[,] m_LastSeenPair;

        public AI(Board i_PToBoard)
        {
            m_GameBoard = i_PToBoard;
            m_MemoryBoardOfPc = new Board(i_PToBoard.Rows, i_PToBoard.Cols);
            m_IsPairForNextTurn = false;
            m_LastSeenPair = new int[2, 2];
            copyBoard();
        }

        public int[,] LastSeenPair
        {
            get
            {
                return m_LastSeenPair;
            }
        }

        private void copyBoard()
        {
            for (int i = 0; i < m_MemoryBoardOfPc.Rows; i++)
            {
                for (int j = 0; j < m_MemoryBoardOfPc.Cols; j++)
                {
                    m_MemoryBoardOfPc.BoardGameMat[i, j] = m_GameBoard.BoardGameMat[i, j];
                }
            }
        }

        public void MemorizeCell(int i_Row, int i_Col)
        {
            m_MemoryBoardOfPc.MarkCellInBoard(i_Row, i_Col);
            for (int i = 0; i < m_MemoryBoardOfPc.Rows; i++)
            {
                for (int j = 0; j < m_MemoryBoardOfPc.Cols; j++)
                {
                    if (i == i_Row && j == i_Col)
                    {
                        continue;
                    }
                        
                    if (m_MemoryBoardOfPc.BoardGameMat[i_Row, i_Col].Value == m_MemoryBoardOfPc.BoardGameMat[i, j].Value && m_MemoryBoardOfPc.BoardGameMat[i, j].IsVisible)
                    {
                        m_IsPairForNextTurn = true;
                        m_LastSeenPair[0, 0] = i_Row;
                        m_LastSeenPair[0, 1] = i_Col;
                        m_LastSeenPair[1, 0] = i;
                        m_LastSeenPair[1, 1] = j;
                    }
                }
            }
        }

        public bool IsPairForNextTurn
        {
            get
            {
                return m_IsPairForNextTurn;
            }
        }

        public bool IsHaveAVisiblePair()
        {
            if (m_GameBoard.IsCellVisible(m_LastSeenPair[0, 0], m_LastSeenPair[0, 1]))
            {
                m_IsPairForNextTurn = false;
            }

            return m_IsPairForNextTurn;
        }
    }
}
