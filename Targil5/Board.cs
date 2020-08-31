using System;
using System.Text;

namespace Targil5
{
    public class Board
    {
        private readonly int r_Rows;
        private readonly int r_Cols;
        private GameCell[,] m_BoardGameMat;
        private int m_HowManyCellsAreOpen;
        
        public Board(int i_Height, int i_Width)
        {
            m_BoardGameMat = new GameCell[i_Height, i_Width];
            r_Rows = i_Height;
            r_Cols = i_Width;
            initialBoard();
            randomizeBoard();
        }

        public bool IsAllBoardFull()
        {
            return m_HowManyCellsAreOpen == r_Cols * r_Rows;
        }

        public bool CheckIfEqual(int i_Row1, int i_Col1, int i_Row2, int i_Col2)
        {
            return m_BoardGameMat[i_Row1, i_Col1].Value == m_BoardGameMat[i_Row2, i_Col2].Value;
        }

        private void randomizeBoard()
        {
            int rowFirst;
            int colFirst;
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < r_Rows; i++)
                {
                    for (int j = 0; j < r_Cols; j++)
                    {
                        rowFirst = CommonFunctions.Random(r_Rows);
                        colFirst = CommonFunctions.Random(r_Cols);
                        CommonFunctions.Swap(ref m_BoardGameMat[i, j], ref m_BoardGameMat[rowFirst, colFirst]);
                    }
                }
            }
        }
        
        private void initialBoard()
        {
            int toAdd = 0, counter = 0;
            for (int i = 0; i < r_Rows; i++)
            {
                for (int j = 0; j < r_Cols; j++)
                {
                    m_BoardGameMat[i, j].Value = toAdd;
                    counter++;
                    if(counter == 2)
                    {
                        counter = 0;
                        toAdd++;
                    }
                }
            }
        }

        public void MarkCellInBoard(int i_Line, int i_Col)
        {
            if (!m_BoardGameMat[i_Line, i_Col].IsVisible)
            {
                m_BoardGameMat[i_Line, i_Col].IsVisible = true;
                m_HowManyCellsAreOpen++;
            }
        }

        public bool IsCellVisible(int i_Row, int i_Col)
        {
            return m_BoardGameMat[i_Row, i_Col].IsVisible;
        }

        public void UnmarkCellInBoard(int i_Line, int i_Col)
        {
            if (m_BoardGameMat[i_Line, i_Col].IsVisible)
            {
                m_BoardGameMat[i_Line, i_Col].IsVisible = false;
                m_HowManyCellsAreOpen--;
            }
        }

        public GameCell[,] BoardGameMat
        {
            get
            {
                return m_BoardGameMat;
            }
        }

        public int Cols
        {
            get
            {
                return r_Cols;
            }
        }

        public int Rows
        {
            get
            {
                return r_Rows;
            }
        }                     
    }
}
