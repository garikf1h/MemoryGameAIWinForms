using System;
using System.Collections.Generic;
using System.Text;

namespace Targil5
{
    internal class PlayGame
    {
        private readonly eGameType r_GameType;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Board m_GameBoard;
        private AI m_AiOfPc;
        
        public PlayGame(string i_FirstUser, string i_SecondUser, int i_Rows, int i_Cols, eGameType i_GameType)
        {
            m_FirstPlayer = new Player(i_FirstUser, 0);
            m_SecondPlayer = new Player(i_SecondUser, 0);
            m_GameBoard = new Board(i_Rows, i_Cols);
            r_GameType = i_GameType;
            if (r_GameType == eGameType.AgainstComp)
            {
                m_AiOfPc = new AI(m_GameBoard);
            }
        }

        public void MarkCell(int i_Line, int i_Col)
        {
            m_GameBoard.MarkCellInBoard(i_Line, i_Col);
        }

        public void UnmarkCell(int i_Line, int i_Col)
        {
            m_GameBoard.UnmarkCellInBoard(i_Line, i_Col);
        }
       
        public bool CheckValidRowCol(int i_Row, int i_Col)
        {
            return i_Col < m_GameBoard.Cols  &&
                 i_Row < m_GameBoard.Rows;
        }

        public Board BoardGame
        {
            get
            {
                return m_GameBoard;
            }
        }

        public void GetScore(out int o_Score1, out int o_Score2)
        {
            o_Score1 = m_FirstPlayer.Score;
            o_Score2 = m_SecondPlayer.Score;
        }

        public void GetPlayersNames(out string o_FirstPlayerName, out string o_SecondPlayerName)
        {
            o_FirstPlayerName = m_FirstPlayer.Name;
            o_SecondPlayerName = m_SecondPlayer.Name;
        }

        public bool UnmarkCellIfIncorrectOrAddPoint(int i_ChosenFirstRow, int i_ChosenFirstCol, int i_ChosenSecondRow, int i_ChosenSecondCol, eCurrentPlayer i_CurrPlayer)
        {
            bool isEqual = false;
            if (r_GameType == eGameType.AgainstComp)
            {
                m_AiOfPc.MemorizeCell(i_ChosenFirstRow, i_ChosenFirstCol);
                m_AiOfPc.MemorizeCell(i_ChosenSecondRow, i_ChosenSecondCol);
            }

            if (m_GameBoard.CheckIfEqual(i_ChosenFirstRow, i_ChosenFirstCol, i_ChosenSecondRow, i_ChosenSecondCol))
            {
                if (i_CurrPlayer == eCurrentPlayer.Player1)
                {
                    m_FirstPlayer.Score++;
                }

                if (i_CurrPlayer == eCurrentPlayer.Player2)
                {
                    m_SecondPlayer.Score++;
                }

                isEqual = true;
            }
            else
            {
                UnmarkCell(i_ChosenFirstRow, i_ChosenFirstCol);
                UnmarkCell(i_ChosenSecondRow, i_ChosenSecondCol);
            }
           
            return isEqual;
        }

        public bool IsEndOfGame()
        {
            return m_GameBoard.IsAllBoardFull();
        }

        public Player FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }
        }

        public void PcTurn(out int[,] o_MovesPcMake)
        {
            o_MovesPcMake = new int[2, 2];
            if (m_AiOfPc.IsHaveAVisiblePair())
            {
                o_MovesPcMake = m_AiOfPc.LastSeenPair;
                MarkCell(o_MovesPcMake[0, 0], o_MovesPcMake[0, 1]);
            }
            else
            {
                PcOneMove(out o_MovesPcMake[0, 0], out o_MovesPcMake[0, 1]);
                MarkCell(o_MovesPcMake[0, 0], o_MovesPcMake[0, 1]);
                m_AiOfPc.MemorizeCell(o_MovesPcMake[0, 0], o_MovesPcMake[0, 1]);
                if (m_AiOfPc.IsHaveAVisiblePair())
                {
                    o_MovesPcMake = m_AiOfPc.LastSeenPair;
                }
                else
                {
                    PcOneMove(out o_MovesPcMake[1, 0], out o_MovesPcMake[1, 1]);
                    m_AiOfPc.MemorizeCell(o_MovesPcMake[1, 0], o_MovesPcMake[1, 1]);
                }
            }

            MarkCell(o_MovesPcMake[1, 0], o_MovesPcMake[1, 1]);      
        }

        public void PcOneMove(out int o_RowPcChoise, out int o_ColPcChoise)
        {
            do
            {
                o_RowPcChoise = CommonFunctions.Random(m_GameBoard.Rows);
                o_ColPcChoise = CommonFunctions.Random(m_GameBoard.Cols);
            }
            while (m_GameBoard.IsCellVisible(o_RowPcChoise, o_ColPcChoise));
            m_GameBoard.MarkCellInBoard(o_RowPcChoise, o_ColPcChoise);
        }
    
        public eGameType GameType
        {
            get
            {
                return r_GameType;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }
        }    

        public Board GameBoard
        {
            get
            {
                return m_GameBoard;
            }
        }

        public bool IsVisibleCell(int i_Row, int i_Col)
        {
            return m_GameBoard.IsCellVisible(i_Row, i_Col);
        }
    }
}
