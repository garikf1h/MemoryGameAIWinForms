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
    public partial class FormReg : Form
    {
        private static string[] SizesArr = { "4X4", "4X5", "4X6", "5X4", "5X6", "6X6" };
        private static int indexNextToShow = 1;
        public FormReg()
        {
            InitializeComponent();
        }
        private void m_SecondPlayerName_Click(object sender, EventArgs e)
        {

        }

        private void m_AgainstAFriend_Click(object sender, EventArgs e)
        {
            if (!m_NameOfSecondPlayer.Enabled)
            {
                m_NameOfSecondPlayer.Enabled = true;
                m_AgainstAFriend.Text = "Against Computer";
                m_NameOfSecondPlayer.Text = "";
            }
            else
            {
                m_NameOfSecondPlayer.Enabled = false;
                m_AgainstAFriend.Text = "Against A Friend";
                m_NameOfSecondPlayer.Text = "-PC-";
            }
        }

        private void m_SizeOfBoard_Click(object sender, EventArgs e)
        {
            m_SizeOfBoard.Text = SizesArr[indexNextToShow++];
            if(indexNextToShow == SizesArr.Length)
            {
                indexNextToShow = 0;
            }
        }
        public void GetEnteredInfo(out int o_Row, out int o_Col, out string o_NameOfFirstPlayer, out string o_NameOfSecondPlayer,out eGameType o_GameType)
        {
             o_Row = int.Parse(m_SizeOfBoard.Text[0].ToString());
             o_Col = int.Parse(m_SizeOfBoard.Text[2].ToString());
              o_NameOfFirstPlayer = m_NameOfFirstPlayer.Text;
            if (m_NameOfSecondPlayer.Enabled)
            {
                o_GameType = eGameType.AgainstPlayer2;
                o_NameOfSecondPlayer = m_NameOfSecondPlayer.Text;
            }
            else
            {
                o_GameType = eGameType.AgainstComp;
                o_NameOfSecondPlayer = "PC";
            }

        }
        private void m_Start_Click(object sender, EventArgs e)
        {
            if (m_NameOfFirstPlayer.Text == "" || m_NameOfSecondPlayer.Text == "")
            {
                DialogResult rs = MessageBox.Show("Name cant be empty", "ERROR");
            }
            else
            {
                this.Close();
            }
            
        }

        
    }
}
