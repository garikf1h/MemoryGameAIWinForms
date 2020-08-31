using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Targil5
{
    public partial class MemoryGameForm : Form
    {
        private Label m_CurrentPlayerLabel;
        private PlayGame m_PlayGame;
        private Label m_FirstPlayerLabel;
        private Label m_SecondPlayerLabel;
        private Button[,] m_Buttons;
        private char[] m_LettersToShow;
        private eCurrentPlayer m_CurrPlayer = eCurrentPlayer.Player1;
        private int MovNum = 1;
        private Point prevMove;
        public MemoryGameForm(int i_rows, int i_cols ,string i_FirstPlayer,string i_SecondPlayer, eGameType i_GameType)
        {
            m_PlayGame = new PlayGame(i_FirstPlayer, i_SecondPlayer, i_rows, i_cols, i_GameType);
            InitializeComponent();
        }

         private void initButtonsArray(int i_Rows, int i_Cols)
        {
            char currLetter = 'A'; 
            this.m_Buttons = new Button[m_PlayGame.BoardGame.Rows , m_PlayGame.BoardGame.Cols];
            m_LettersToShow = new char[(i_Rows * i_Cols) / 2];
            for (int i = 0; i < i_Rows; i++)
            {
                for (int j = 0; j < i_Cols; j++)
                {
                    m_Buttons[i,j] = new Button();
                }
            }
            for (int i = 0; i < m_LettersToShow.Length; i++)
            {
                m_LettersToShow[i] = currLetter++;
            }
        }
        private void InitializeComponent()
        {
            this.initButtonsArray(m_PlayGame.BoardGame.Rows, m_PlayGame.BoardGame.Cols);
            this.showBoard();
            initCurrPlayerLabel();
            initFirstPlayerLabel();
            initSecondPlayerLabel();
            initForm();
        }
        private void initForm()
        {
            updateScore();
            this.AutoSize = true;
            this.Controls.Add(this.m_SecondPlayerLabel);
            this.Controls.Add(this.m_FirstPlayerLabel);
            this.Controls.Add(this.m_CurrentPlayerLabel);
            this.Name = "MemoryGameForm";
            this.Text = "Memory Game";
        }
        private void initCurrPlayerLabel()
        {
            this.m_CurrentPlayerLabel = new Label();
            this.m_CurrentPlayerLabel.AutoSize = true;
            this.m_CurrentPlayerLabel.BackColor = System.Drawing.Color.LightGreen;
            this.m_CurrentPlayerLabel.Location = new System.Drawing.Point(10, this.m_Buttons[m_PlayGame.BoardGame.Rows - 1, 0].Location.Y + 100);
            this.m_CurrentPlayerLabel.Name = "m_CurrentPlayerLabel";
            this.m_CurrentPlayerLabel.Size = new System.Drawing.Size(103, 17);
            this.m_CurrentPlayerLabel.TabIndex = 0;
            this.m_CurrentPlayerLabel.Text = "Current Player:" + m_PlayGame.FirstPlayer.Name;
        }
        private void initFirstPlayerLabel()
        {
            this.m_FirstPlayerLabel = new Label();
            this.m_FirstPlayerLabel.AutoSize = true;
            this.m_FirstPlayerLabel.Location = new System.Drawing.Point(10, m_CurrentPlayerLabel.Location.Y + 20);
            this.m_FirstPlayerLabel.Name = "m_FirstPlayerLabel";
            this.m_FirstPlayerLabel.BackColor = Color.LightGreen;
            this.m_FirstPlayerLabel.Size = new System.Drawing.Size(46, 17);
            this.m_FirstPlayerLabel.TabIndex = 1;
        }
        private void initSecondPlayerLabel()
        {
            this.m_SecondPlayerLabel = new Label();
            this.m_SecondPlayerLabel.AutoSize = true;
            this.m_SecondPlayerLabel.Location = new System.Drawing.Point(10, m_FirstPlayerLabel.Location.Y + 20);
            this.m_SecondPlayerLabel.Name = "m_SecondPlayerLabel";
            this.m_SecondPlayerLabel.BackColor = Color.LightBlue;
            this.m_SecondPlayerLabel.Size = new System.Drawing.Size(46, 17);
            this.m_SecondPlayerLabel.TabIndex = 2;
        }
        private void changePlayer()
        {
            
            if (m_CurrPlayer == eCurrentPlayer.Player1)
            {
                m_CurrPlayer = eCurrentPlayer.Player2;
                this.m_CurrentPlayerLabel.Text= "Current Player: " + m_PlayGame.SecondPlayer.Name;
                this.m_CurrentPlayerLabel.BackColor = this.m_SecondPlayerLabel.BackColor;
            }
            else
            {
                m_CurrPlayer = eCurrentPlayer.Player1;
                this.m_CurrentPlayerLabel.Text = "Current Player: " + m_PlayGame.FirstPlayer.Name;
                this.m_CurrentPlayerLabel.BackColor = this.m_FirstPlayerLabel.BackColor;
            }
        }
        private void ClearAll(string i_Name1, string i_Name2)
        {
            m_PlayGame = new PlayGame(i_Name1, i_Name2, m_PlayGame.GameBoard.Rows, m_PlayGame.GameBoard.Cols, m_PlayGame.GameType);
            Board Board = m_PlayGame.BoardGame;
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Cols; j++)
                {
                    GameCell GameCell = Board.BoardGameMat[i, j];
                    m_Buttons[i, j].BackColor = System.Drawing.SystemColors.ControlDark;
                    m_Buttons[i, j].Click += m_Button_Click;
                }
            }
            updateScore();
            m_CurrPlayer = eCurrentPlayer.Player1;
            this.m_CurrentPlayerLabel.Text = "Current Player: " + m_PlayGame.FirstPlayer.Name;
            this.m_CurrentPlayerLabel.BackColor = this.m_FirstPlayerLabel.BackColor;
        }
        private void updateScore()
        {
            this.m_FirstPlayerLabel.Text = m_PlayGame.FirstPlayer.Name + ": " + m_PlayGame.FirstPlayer.Score;
            this.m_SecondPlayerLabel.Text = m_PlayGame.SecondPlayer.Name + ": " + m_PlayGame.SecondPlayer.Score;
        }
        private void m_Button_Click(object sender, EventArgs e)
        {
            Point currMove = new Point();
            findButton(sender as Button, ref currMove);
            m_PlayGame.MarkCell(currMove.X, currMove.Y);
            backroundColorAndEraseEvent(currMove.X, currMove.Y);
            renderBoard();
            if (MovNum == 2)
            {
                secondMoveOfAPlayer(currMove);
            }
            checkIfEndOfGame();
            renderBoard();
            prevMove = currMove;
            MovNum = changeMoveNum(MovNum);
        }
        private void secondMoveOfAPlayer(Point i_CurrMove)
        {
                System.Threading.Thread.Sleep(2000);
                if (!m_PlayGame.UnmarkCellIfIncorrectOrAddPoint(prevMove.X, prevMove.Y, i_CurrMove.X, i_CurrMove.Y, m_CurrPlayer))
                {
                    resetButton(i_CurrMove.X, i_CurrMove.Y);
                    resetButton(prevMove.X, prevMove.Y);
                }
                updateScore();
                changePlayer();
                renderBoard();
                checkIfEndOfGame();

            if (m_PlayGame.GameType == eGameType.AgainstComp)
            {
                    againstComp();
            }
        }


        private void againstComp()
        {
            int[,] MovesMade;
            m_PlayGame.PcTurn(out MovesMade);
            renderBoard();
            backroundColorAndEraseEvent(MovesMade[0, 0], MovesMade[0, 1]);
            backroundColorAndEraseEvent(MovesMade[1, 0], MovesMade[1, 1]);
            System.Threading.Thread.Sleep(2000);

            if (!m_PlayGame.UnmarkCellIfIncorrectOrAddPoint(MovesMade[0, 0], MovesMade[0, 1], MovesMade[1, 0], MovesMade[1, 1], eCurrentPlayer.Player2))
            {
                resetButton(MovesMade[0, 0], MovesMade[0, 1]);
                resetButton(MovesMade[1, 0], MovesMade[1, 1]);
            }
            else
            {
                updateScore();
            }
            renderBoard();
            changePlayer();
            checkIfEndOfGame();

        }
        private int changeMoveNum(int i_MoveNum)
        {
            if (MovNum == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }


        private void resetButton(int i,int j)
        {
            m_Buttons[i, j].Click += m_Button_Click;
            m_Buttons[i, j].BackColor = SystemColors.ControlDark;

        }
        private void backroundColorAndEraseEvent(int i, int j)
        {
            if (m_CurrPlayer == eCurrentPlayer.Player1)
                m_Buttons[i, j].BackColor = Color.LightGreen;
            else
                m_Buttons[i, j].BackColor = Color.LightBlue;
            this.Update();
            m_Buttons[i, j].Click -= m_Button_Click;

        }
        private void checkIfEndOfGame()
        {
            StringBuilder msg = new StringBuilder();
            if (m_PlayGame.IsEndOfGame())
            {
                int player1Score, player2Score;
                string player1Name, player2Name;
                m_PlayGame.GetScore(out player1Score, out player2Score);
                m_PlayGame.GetPlayersNames(out player1Name, out player2Name);
                showMessageBox(player1Score, player2Score, player1Name, player2Name);
            }
        }

        private void showMessageBox(int i_Score1, int i_Score2, string i_Name1, string i_Name2)
        {
            DialogResult result = DialogResult.No;
            if (i_Score1 > i_Score2)
                result = MessageBox.Show("The winner is: " + i_Name1 + " " + Environment.NewLine + " Do you want to play a new game?", "Winner", MessageBoxButtons.YesNo);
            if (i_Score1 < i_Score2)
                result = MessageBox.Show("The winner is: " + i_Name2 + " " + Environment.NewLine + " Do you want to play a new game?", "Winner", MessageBoxButtons.YesNo);
            if (i_Score1 == i_Score2)
                result = MessageBox.Show("This is a tie" + Environment.NewLine + " Do you want to play a new game?", "Winner", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                ClearAll(i_Name1, i_Name2);
            }
        }
        private void renderBoard()
        {
            for (int i = 0; i < m_PlayGame.GameBoard.Rows; i++)
            {
                for (int j = 0; j < m_PlayGame.GameBoard.Cols; j++)
                {
                    if (m_PlayGame.GameBoard.BoardGameMat[i, j].IsVisible)
                    {
                        m_Buttons[i, j].Text = m_LettersToShow[m_PlayGame.BoardGame.BoardGameMat[i, j].Value].ToString();
                    }
                    else
                    {
                        m_Buttons[i, j].Text = "";
                    }
                }
            }
            this.Update();
        }
        private void findButton(Button i_Button, ref Point io_p)
        {
            for (int i = 0; i < m_PlayGame.GameBoard.Rows; i++)
            {
                for (int j = 0; j < m_PlayGame.GameBoard.Cols; j++)
                {
                    if (i_Button == m_Buttons[i, j])
                    {
                        io_p.X = i;
                        io_p.Y = j;
                    }
                }
            }
        }
        private void initializeButton(Button i_Button)
        {
            i_Button.Size = new System.Drawing.Size(80, 70);
            i_Button.UseVisualStyleBackColor = false;
            i_Button.UseWaitCursor = false;
            i_Button.Click += m_Button_Click;
            i_Button.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(i_Button);
        }
        private void showBoard() 
        {
            Board Board = m_PlayGame.BoardGame;
            int x=10, y=40;
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Cols; j++)
                {
                        m_Buttons[i, j].Location = new System.Drawing.Point(x, y);
                        initializeButton(m_Buttons[i, j]);
                        x += 80;
                }
                x = 10;
                y += 70;
            } 
        }

    }
}


        
    
 

